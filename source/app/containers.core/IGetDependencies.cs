using System;

namespace app.containers.core
{
  public interface IGetDependencies
  {
    Dependency an<Dependency>();
    object an(Type type);
  }
}