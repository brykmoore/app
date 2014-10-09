using System.Collections.Generic;
using app.containers.basic;
using app.containers.core;
using app.request_handling;
using app.request_handling.aspnet;
using app.stubs;

namespace app.startup
{
  public class StartApplication
  {
    static IList<ICreateAnObject> factories;
    static IGetDependencies container;

    public static void run()
    {
      configure_the_container();
      register_request_handling_dependencies();
    }

    static void register_request_handling_dependencies()
    {
      register<IHandleAllWebRequests>(() => new FrontController(container.an<IGetHandlersForRequests>()));

      register<IGetHandlersForRequests>(
        () => new HandlerRegistry(container.an<IEnumerable<IHandleOneRequest>>(),
          container.an<ICreateTheMissingHandler>()));

      register<IEnumerable<IHandleOneRequest>>(() => new StubHandlers());

      register<ICreateTheMissingHandler>(() => StubRuntimeDelegates.web.missing_handler_builder);

      register<IDisplayInformation>(() => new WebFormDisplayEngine(container.an<ICreateWebFormBasedViews>(),
        container.an<IGetTheCurrentRequest>()));

      register<ICreateWebFormBasedViews>(
        () => new WebFormFactory(container.an<IFindPathsToWebPages>(), container.an<ICreatePageInstances>()));

      register<ICreatePageInstances>(() => StubRuntimeDelegates.web.create_page);

      register<IFindPathsToWebPages>(() => new StubPathRegistry());

      register<ICreateControllerRequestsFromAspNetRequests>(() => StubRuntimeDelegates.web.request_builder);

      register<IGetTheCurrentRequest>(() => StubRuntimeDelegates.web.get_current_request);
    }

    static void configure_the_container()
    {
      factories = new List<ICreateAnObject>();

      var factory_registry = new DependencyFactories(factories,
        StubRuntimeDelegates.startup.create_missing_dependency_factory);

      container = new Container(factory_registry, StubRuntimeDelegates.startup.create_dependency_error_builder);
      Dependencies.access_the_container = () => container;
    }

    static void register<Contract>(ICreate factory)
    {
      var type_specification = StubRuntimeDelegates.containers.is_instance_of<Contract>();
      factories.Add(new ObjectFactory(type_specification, new BasicFactory(factory)));
    }
  }
}