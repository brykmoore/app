using System.Collections;
using System.Collections.Generic;
using app.catalog_browsing;
using app.request_handling;

namespace app.stubs
{
  public class StubHandlers : IEnumerable<IHandleOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IHandleOneRequest> GetEnumerator()
    {
      yield return new Handler(x => true, new ViewTheMainDepartmentsInTheStore());
    }
  }
}