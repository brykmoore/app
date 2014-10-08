using System.Collections.Generic;
using app.catalog_browsing;
using app.request_handling;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<IRunAFeature,
      ViewTheMainDepartmentsInTheStore>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        departments = depends.on<IFindDepartments>();
        display_engine = depends.on<IDisplayInformation>();
        request = fake.an<IProvideRequestDetails>();
        the_main_departments = new List<DepartmentLineItem>();

        departments.setup(x => x.get_the_main_departments()).Return(the_main_departments);
      };

      Because b = () =>
        sut.handle(request);

      It displays_the_main_departments = () =>
        display_engine.received(x => x.display(the_main_departments));
        

      static IFindDepartments departments;
      static IProvideRequestDetails request;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentLineItem> the_main_departments;
    }
  }
}