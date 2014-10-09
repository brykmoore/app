using System.Collections.Generic;
using app.containers.basic;
using app.containers.core;
using app.stubs;

namespace app.startup
{
  public class ConfiguringTheContainer : IRunAStartupStep
  {
    IProvideStartupFeatures startup;

    public ConfiguringTheContainer(IProvideStartupFeatures startup)
    {
      this.startup = startup;
    }

    public void run()
    {
      var factories = new List<ICreateAnObject>();

      var factory_registry = new DependencyFactories(factories,
        StubRuntimeDelegates.startup.create_missing_dependency_factory);

      var container = new Container(factory_registry, StubRuntimeDelegates.startup.create_dependency_error_builder);
      Dependencies.access_the_container = () => container;
    }
  }
}