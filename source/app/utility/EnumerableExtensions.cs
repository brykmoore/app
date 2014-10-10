using System.Collections;
using System.Collections.Generic;
using System.Linq;
using app.utility.mapping;

namespace app.utility
{
  public class MappingIterator<Input, Output> : IEnumerable<Output>
  {
    IEnumerable<Input> source;
    IMapper<Input, Output> mapper;

    public MappingIterator(IEnumerable<Input> source, IMap<Input, Output> mapper):this(source, mapper.map)
    {
    }
    public MappingIterator(IEnumerable<Input> source, IMapper<Input, Output> mapper)
    {
      this.source = source;
      this.mapper = mapper;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<Output> GetEnumerator()
    {
      foreach (var input in source) yield return mapper(input);
    }
  }

  public static class EnumerableExtensions
  {
    public static void each<T>(this IEnumerable<T> iterator, IProcessAnElement<T> visitor)
    {
      foreach (var item in iterator) visitor(item);
    }

    public static IEnumerable<Output> map<Input, Output>(this IEnumerable<Input> iterator, IMapper<Input, Output> mapper)
    {
      return iterator.Select(mapper.Invoke);
    }

    public static IEnumerable<Output> map<Input, Output>(this IEnumerable<Input> iterator, IMap<Input, Output> mapper)
    {
      return iterator.map(mapper.map);
    }

    public static IEnumerable<Output> map<Input, Output, Mapper>(this IEnumerable<Input> iterator)
      where Mapper : IMap<Input, Output>, new()
    {
      return iterator.map(new Mapper());
    }
  }
}