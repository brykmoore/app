using System;

namespace app.containers.basic
{
  public delegate Exception ICreateACustomErrorWhenTheDependencyCantBeCreated(Type type_that_could_not_be_created,Exception inner);
}