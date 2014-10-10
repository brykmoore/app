using System.Collections.Generic;

namespace app.utility
{
  public static class IteratingExtensions
  {
    public static void each<T>(this IEnumerable<T> iterator, IProcessAnElement<T> visitor)
    {
      foreach (var item in iterator) visitor(item);
    } 
  }
}