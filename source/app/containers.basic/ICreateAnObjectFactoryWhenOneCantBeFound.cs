using System;

namespace app.containers.basic
{
  public delegate ICreateAnObject ICreateAnObjectFactoryWhenOneCantBeFound(Type type_that_has_no_factory);
}