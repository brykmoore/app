using System;
using System.Reflection;
using app.utility.mapping;

namespace app.reflection
{
  public class TypeNameToTypeClass : IMap<string, Type>
  {
    Assembly resolution_assembly;

    public TypeNameToTypeClass(Assembly resolution_assembly)
    {
      this.resolution_assembly = resolution_assembly;
    }

    public TypeNameToTypeClass():this(Assembly.GetExecutingAssembly())
    {
    }

    public Type map(string input)
    {
      return resolution_assembly.GetType(input);
    }
  }
}