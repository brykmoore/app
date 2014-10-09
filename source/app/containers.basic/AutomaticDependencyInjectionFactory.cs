using System;
using System.Linq;
using app.containers.core;

namespace app.containers.basic
{
  public class AutomaticDependencyInjectionFactory : ICreateOneObject
  {
    Type type_to_create;
    IGetDependencies container;
    IPickTheContructorUsedToCreateAType ctor_picker;

    public AutomaticDependencyInjectionFactory(Type type_to_create, IPickTheContructorUsedToCreateAType ctor_picker,
      IGetDependencies container)
    {
      this.type_to_create = type_to_create;
      this.container = container;
      this.ctor_picker = ctor_picker;
    }

    public object create()
    {
      var ctor = ctor_picker(type_to_create);

      var parameters =
        ctor.GetParameters().Select(x => container.an(
          x.ParameterType)).ToArray();

      return ctor.Invoke(parameters);
    }
  }
}