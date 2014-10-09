using System;
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

      factories.Add(add_object_factory<IHandleAllWebRequests>(() => new FrontController(container.an<IGetHandlersForRequests>())));

      factories.Add(add_object_factory<IGetHandlersForRequests>(() => new HandlerRegistry(container.an<IEnumerable<IHandleOneRequest>>(),
          container.an<ICreateTheMissingHandler>())));
        
      factories.Add(add_object_factory<IEnumerable<IHandleOneRequest>>(() => new StubHandlers()));

      factories.Add(add_object_factory<ICreateTheMissingHandler>(() => StubRuntimeDelegates.web.missing_handler_builder));

      factories.Add(add_object_factory<IDisplayInformation>(() => new WebFormDisplayEngine(container.an<ICreateWebFormBasedViews>(),
          container.an<IGetTheCurrentRequest>())));

      factories.Add(add_object_factory<ICreateWebFormBasedViews>(() => new WebFormFactory(container.an<IFindPathsToWebPages>(), container.an<ICreatePageInstances>())));
      
      factories.Add(add_object_factory<ICreatePageInstances>(() => StubRuntimeDelegates.web.create_page));
      
      factories.Add(add_object_factory<IFindPathsToWebPages>(() => new StubPathRegistry()));

      factories.Add(add_object_factory<ICreateControllerRequestsFromAspNetRequests>(() => StubRuntimeDelegates.web.request_builder));

      factories.Add(add_object_factory<IGetTheCurrentRequest>(() => StubRuntimeDelegates.web.get_current_request));

    }

    private static ICreateAnObject add_object_factory<Contract>(ICreate factory)
      {
          return new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<Contract>(), new BasicFactory(factory));
      }
  }
}