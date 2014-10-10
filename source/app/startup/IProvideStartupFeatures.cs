using System.Collections.Generic;
using app.containers.basic;

namespace app.startup
{
  public interface IProvideStartupFeatures
  {
    void register<Contract, Implementation>() where Implementation : Contract;
    void register<Contract>(Contract instance);
    IEnumerable<ICreateAnObject> factories { get; }
  }
}