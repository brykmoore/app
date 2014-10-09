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
    public static void run()
    {
      var factories = new List<ICreateAnObject>();
      var factory_registry = new DependencyFactories(factories,
        StubRuntimeDelegates.startup.create_missing_dependency_factory);
      var container = new Container(factory_registry, StubRuntimeDelegates.startup.create_dependency_error_builder);
      Dependencies.access_the_container = () => container;

      //register dependencies
      factories.Add(new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<IHandleAllWebRequests>(),
        new BasicFactory(() => new FrontController(container.an<IGetHandlersForRequests>()))));

      factories.Add(new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<IGetHandlersForRequests>(),
        new BasicFactory(() => new HandlerRegistry(container.an<IEnumerable<IHandleOneRequest>>(),
          container.an<ICreateTheMissingHandler>()))));

      factories.Add(new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<IEnumerable<IHandleOneRequest>>(),
        new BasicFactory(() => new StubHandlers())));

      factories.Add(new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<ICreateTheMissingHandler>(),
        new BasicFactory(() => StubRuntimeDelegates.web.missing_handler_builder)));

      factories.Add(new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<IDisplayInformation>(),
        new BasicFactory(() => new WebFormDisplayEngine(container.an<ICreateWebFormBasedViews>(),
          container.an<IGetTheCurrentRequest>()))));

      factories.Add(new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<ICreateWebFormBasedViews>(),
        new BasicFactory(
          () => new WebFormFactory(container.an<IFindPathsToWebPages>(), container.an<ICreatePageInstances>()))));

      factories.Add(new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<ICreatePageInstances>(),
        new BasicFactory(() => StubRuntimeDelegates.web.create_page)));

      factories.Add(new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<IFindPathsToWebPages>(),
        new BasicFactory(() => new StubPathRegistry())));

      factories.Add(
        new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<ICreateControllerRequestsFromAspNetRequests>(),
          new BasicFactory(
            () => StubRuntimeDelegates.web.request_builder)));

      factories.Add(
        new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<IGetTheCurrentRequest>(),
          new BasicFactory(
            () => StubRuntimeDelegates.web.get_current_request)));
    }
  }
}