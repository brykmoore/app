using System;
using System.Collections.Generic;

namespace app.containers.core
{
  public interface IGetDependencies
  {
    Dependency an<Dependency>();
    IEnumerable<Dependency> all<Dependency>();
    IEnumerable<object> all(Type dependency_type);
    object an(Type type);
  }
}