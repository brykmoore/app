using System.Collections.Generic;
using System.Linq;
using app.catalog_browsing;
using app.request_handling;

namespace app.catalog_browser.queries
{
  public class GetProductsInDepartment : IFetchA<IEnumerable<ProductSummaryLine>>
  {
    public IEnumerable<ProductSummaryLine> fetch_using(IProvideRequestDetails request)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductSummaryLine{name = x.ToString("Product 0")});
    }
  }
}