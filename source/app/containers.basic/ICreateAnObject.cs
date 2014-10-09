using System;

namespace app.containers.basic
{
  public interface ICreateAnObject : ICreateOneObject
  {
    bool can_create(Type type); }
}