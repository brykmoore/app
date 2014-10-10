using System.Collections;
using System.Collections.Generic;

namespace app.utility.mapping
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
}