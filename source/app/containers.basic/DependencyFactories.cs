using System;

namespace app.containers.basic
{
  public class DependencyFactories : IGetFactoriesForObjects
  {
    public ICreateAnObject get_factory_that_can_create(Type type)
    {
      throw new NotImplementedException();
    }
  }
}