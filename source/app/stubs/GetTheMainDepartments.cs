using System.Collections.Generic;
using System.Linq;
using app.catalog_browsing;
using app.request_handling;

namespace app.stubs
{
  public class GetTheMainDepartments : IFetchA<IEnumerable<DepartmentLineItem>>
  {
    public IEnumerable<DepartmentLineItem> fetch_using(IProvideRequestDetails request)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentLineItem {name = x.ToString("Department 0")});
    }
  }
}