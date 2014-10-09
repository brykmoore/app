using System;
using System.Reflection;

namespace app.containers.basic
{
  public delegate ConstructorInfo IPickTheContructorUsedToCreateAType(Type type);
}