using System;

namespace app.utility
{
  public static class FunctionExtensions
  {
    public static Func<T, T> curry<T>(this Func<T, T, T> initial, T argument)
    {
      return (x) => initial(argument, x);
    }

    public static Func<T, T, T> memoize<T>(this Func<T, T, T> method)
    {
      return (x, y) =>
      {
        return method(x, y);
      };
    }
  }
}