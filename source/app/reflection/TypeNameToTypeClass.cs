﻿using System;
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
      throw new NotImplementedException();
    }
  }
}