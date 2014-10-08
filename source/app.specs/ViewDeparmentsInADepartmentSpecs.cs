using System.Collections.Generic;
using app.catalog_browsing;
using app.request_handling;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ViewDeparmentsInADepartment))]
  public class ViewDeparmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<IRunAFeature,
      ViewDeparmentsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideRequestDetails>();
        display_engine = depends.on<IDisplayInformation>();
        departments = depends.on<IFindDepartments>();
        departments_in_department = new List<DepartmentLineItem>();
        input_model = new DeparmentsInDepartmentRequest();

        request.setup(x => x.map<DeparmentsInDepartmentRequest>()).Return(input_model);
        departments.setup(x => x.get_departments_using(input_model)).Return(departments_in_department);
      };

      Because b = () =>
        sut.handle(request);

      It displays_the_departments_in_the_department = () =>
        display_engine.received(x => x.display(departments_in_department));

      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentLineItem> departments_in_department;
      static IProvideRequestDetails request;
      static IFindDepartments departments;
      static DeparmentsInDepartmentRequest input_model;
    }
  }
}