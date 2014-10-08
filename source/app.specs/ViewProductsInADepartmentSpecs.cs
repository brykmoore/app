 using System.Collections.Generic;
 using app.catalog_browsing;
 using app.request_handling;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ViewProductsInADepartmentSpecs))]  
  public class ViewProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<IRunAFeature,
      ViewProductsInADepartment>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayInformation>();
        products = depends.on<IFindProducts>();

        request = fake.an<IProvideRequestDetails>();
        department_products = new List<ProductSummaryLine>();
        input_model = new ProductsInDepartmentRequest();

        request.setup(x => x.map<ProductsInDepartmentRequest>()).Return(input_model);
        products.setup(x => x.get_products_using(input_model)).Return(department_products);
      };
      Because b = () =>
        sut.handle(request);

      It displays_the_products_in_a_department = () =>
        display_engine.received(x => x.display(department_products));

      static IDisplayInformation display_engine;
      static IEnumerable<ProductSummaryLine> department_products;
      static IProvideRequestDetails request;
      static IFindProducts products;
      static ProductsInDepartmentRequest input_model;
    }
  }
}
