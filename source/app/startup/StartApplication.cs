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
      initialize_the_container();
      configure_front_controller();
    }

    static void configure_front_controller()
    {
      register<IHandleAllWebRequests, FrontController>();
      register<IGetHandlersForRequests, HandlerRegistry>();
      register<IEnumerable<IHandleOneRequest>, StubHandlers>();
      register<IDisplayInformation, WebFormDisplayEngine>();
      register<ICreateWebFormBasedViews, WebFormFactory>();
      register<IFindPathsToWebPages, StubPathRegistry>();

      register(StubRuntimeDelegates.web.create_page);
      register(StubRuntimeDelegates.web.missing_handler_builder);
      register(StubRuntimeDelegates.web.request_builder);
      register(StubRuntimeDelegates.web.get_current_request);
    }

    public class TimedHandlerRegistry : IGetHandlersForRequests
    {
      public IHandleOneRequest get_the_handler_that_can_handle(IProvideRequestDetails request)
      {
        throw new System.NotImplementedException();
      }
    }

    static void initialize_the_container()
    {
      factories = new List<ICreateAnObject>();

      var factory_registry = new DependencyFactories(factories,
        StubRuntimeDelegates.startup.create_missing_dependency_factory);

      container = new Container(factory_registry, StubRuntimeDelegates.startup.create_dependency_error_builder);
      Dependencies.access_the_container = () => container;
    }

    static void register<Contract>(Contract implementation)
    {
      register<Contract>(new BasicFactory(() => implementation));
    }

    static void register<Contract, Implementation>() where Implementation : Contract
    {
      register<Contract>(new AutomaticDependencyInjectionFactory(typeof(Implementation),
        StubRuntimeDelegates.startup.greediest_ctor, container));
    }

    static void register<Contract>(ICreateOneObject factory)
    {
      var type_specification = StubRuntimeDelegates.containers.is_instance_of<Contract>();
      factories.Add(new ObjectFactory(type_specification, factory));
    }
  }
}