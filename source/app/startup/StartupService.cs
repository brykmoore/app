using System.Collections.Generic;
using app.containers.basic;
using app.containers.core;
using app.stubs;

namespace app.startup
{
  public class StartupService : IProvideStartupFeatures
  {
    IGetDependencies container;
    public IList<ICreateAnObject> factory_list = new List<ICreateAnObject>();

    public StartupService(IGetDependencies container)
    {
      this.container = container;
    }

    public void register<Contract, Implementation>() where Implementation : Contract
    {
      register<Contract>(new AutomaticDependencyInjectionFactory(typeof(Implementation),
          StubRuntimeDelegates.startup.greediest_ctor,
          container
          ));
    }

    public void register<Contract>(Contract instance)
    {
      register<Contract>(new BasicFactory(() => instance));
    }

    void register<Contract>(ICreateOneObject factory)
    {
      factory_list.Add(new ObjectFactory(StubRuntimeDelegates.containers.is_instance_of<Contract>(), factory));
    }

    public IEnumerable<ICreateAnObject> factories
    {
      get { return factory_list; }
    }

  }
}