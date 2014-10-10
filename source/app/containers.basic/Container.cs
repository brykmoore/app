using System;
using System.Collections.Generic;
using app.containers.core;

namespace app.containers.basic
{
  public class Container : IGetDependencies
  {
    IGetFactoriesForObjects factories;
    ICreateACustomErrorWhenTheDependencyCantBeCreated custom_error_builder;

    public Container(IGetFactoriesForObjects factories, ICreateACustomErrorWhenTheDependencyCantBeCreated custom_error_builder)
    {
      this.factories = factories;
      this.custom_error_builder = custom_error_builder;
    }

    public Dependency an<Dependency>()
    {
      return (Dependency) an(typeof(Dependency));
    }

    public IEnumerable<Dependency> all<Dependency>()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<object> all(Type dependency_type)
    {
      throw new NotImplementedException();
    }

    public object an(Type type)
    {
      var factory = factories.get_factory_that_can_create(type);

      try
      {
        return factory.create();
      }
      catch (Exception e)
      {
        throw custom_error_builder(type, e);
      }
    }
  }
}