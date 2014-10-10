using System.Collections.Generic;
using System.Linq;
using app.utility.mapping;

namespace app.utility
{
  public static class EnumerableExtensions
  {
    public static void each<T>(this IEnumerable<T> iterator, IProcessAnElement<T> visitor)
    {
      foreach (var item in iterator) visitor(item);
    } 

    public static IEnumerable<Output> map<Input,Output>(this IEnumerable<Input> iterator, IMapper<Input, Output> mapper)
    {
      return iterator.Select(mapper.Invoke);
    } 

    public static IEnumerable<Output> map<Input,Output>(this IEnumerable<Input> iterator, IMap<Input, Output> mapper)
    {
      return iterator.map(mapper.map);
    } 

    public static IEnumerable<Output> map<Input,Output, Mapper>(this IEnumerable<Input> iterator) where Mapper : IMap<Input, Output>, new()
    {
      return iterator.map(new Mapper());
    } 
  }
}