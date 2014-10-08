using System.Collections.Generic;
using System.Linq;
using app.catalog_browsing;

namespace app.stubs
{
  public class StubDepartments : IFindDepartments
  {
    public IEnumerable<DepartmentLineItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentLineItem {name = x.ToString("Department 0")});
    }
  }
}