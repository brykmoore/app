using System;

namespace app.containers.basic
{
  public class ObjectFactory : ICreateAnObject
  {
    IMatchAType type_specification;
    ICreateOneObject real_factory;

    public ObjectFactory(IMatchAType type_specification, ICreateOneObject real_factory)
    {
      this.type_specification = type_specification;
      this.real_factory = real_factory;
    }

    public bool can_create(Type type)
    {
      return type_specification(type);
    }

    public object create()
    {
      return real_factory.create();
    }
  }
}