using System;
using System.Collections.Generic;

namespace app.utility
{
  public static class FunctionExtensions
  {
    public static Func<T, T> curry<T>(this Func<T, T, T> initial, T argument)
    {
      return (x) => initial(argument, x);
    }

    public class CustomKey<T> : IEquatable<CustomKey<T>>
    {
      readonly T first;
      readonly T second;

      public CustomKey(T first, T second)
      {
        this.first = first;
        this.second = second;
      }

      public bool Equals(CustomKey<T> other)
      {
        return this.first.Equals(other.first) &&
               this.second.Equals(other.second);
      }

      public override int GetHashCode()
      {
        return first.GetHashCode() ^ second.GetHashCode();
      }
    }

    public static Func<T, T, T> memoize<T>(this Func<T, T, T> original)
    {
      var cache = new Dictionary<CustomKey<T>, T>();

      return (x, y) =>
      {
        var key = new CustomKey<T>(x, y);
        if (cache.ContainsKey(new CustomKey<T>(x, y))) return cache[key];

        var value = original(x, y);
        cache[key] = value;
        return value;
      };
    }
  }
}