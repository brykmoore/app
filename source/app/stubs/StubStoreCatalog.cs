using System.Collections.Generic;
using System.Linq;
using app.catalog_browsing;

namespace app.stubs
{
  public class StubStoreCatalog : IFindDepartments, IFindProducts
  {
    public IEnumerable<DepartmentLineItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentLineItem {name = x.ToString("Department 0")});
    }

    public IEnumerable<DepartmentLineItem> get_departments_using(DeparmentsInDepartmentRequest request)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentLineItem {name = x.ToString("Sub Department 0")});
    }

    public IEnumerable<ProductSummaryLine> get_products_using(ProductsInDepartmentRequest request)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductSummaryLine{name = x.ToString("Product 0")});
    }
  }
}