using app.request_handling;
using app.stubs;

namespace app.catalog_browsing
{
  public class ViewProductsInADepartment :IRunAFeature
  {
    IDisplayInformation display_engine;
    IFindProducts products;

    public ViewProductsInADepartment(IDisplayInformation display_engine, IFindProducts products)
    {
      this.display_engine = display_engine;
      this.products = products;
    }

    public ViewProductsInADepartment():this(new StubDisplayEngine(), 
      new StubStoreCatalog())
    {
    }

    public void handle(IProvideRequestDetails request)
    {
      var input = request.map<ProductsInDepartmentRequest>();
      var department_products = products.get_products_using(input);

      display_engine.display(department_products);
    }
  }
}