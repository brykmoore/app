using System;
using app.utility.mapping;

namespace app.reflection
{
  public class TypeNameToTypeClass : IMap<string, Type>
  {
    Type resolution_type;

    public TypeNameToTypeClass(Type resolution_type)
    {
      this.resolution_type = resolution_type;
    }

    public Type map(string input)
    {
      return resolution_type.Assembly.GetType(input);
    }
  }
}