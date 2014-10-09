using System;

namespace app.containers.basic
{
  public interface IGetFactoriesForObjects
  {
    ICreateAnObject get_factory_that_can_create(Type type);
  }
}