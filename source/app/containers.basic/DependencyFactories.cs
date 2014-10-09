using System;
using System.Collections.Generic;
using System.Linq;

namespace app.containers.basic
{
  public class DependencyFactories : IGetFactoriesForObjects
  {
    IEnumerable<ICreateAnObject> factories;
    ICreateAnObjectFactoryWhenOneCantBeFound missing_factory_builder;

    public DependencyFactories(IEnumerable<ICreateAnObject> factories, ICreateAnObjectFactoryWhenOneCantBeFound missing_factory_builder)
    {
      this.factories = factories;
      this.missing_factory_builder = missing_factory_builder;
    }

    public ICreateAnObject get_factory_that_can_create(Type type)
    {
      return factories.FirstOrDefault(x => x.can_create(type)) ?? missing_factory_builder(type); 
    }
  }
}