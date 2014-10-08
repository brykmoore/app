using System.Collections.Generic;

namespace app.catalog_browsing
{
  public interface IFindProducts
  {
    IEnumerable<ProductSummaryLine> get_products_using(ProductsInDepartmentRequest request);
  }
}