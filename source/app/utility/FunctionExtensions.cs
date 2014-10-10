using System;

namespace app.utility
{
  public static class FunctionExtensions
  {
    public static Func<T, T> curry<T>(this Func<T, T, T> initial, T argument)
    {
      throw new NotImplementedException(); 
    }
  }
}