using app.request_handling;
using app.request_handling.aspnet;
using app.stubs;

namespace app.catalog_browsing
{
  public class ViewDeparmentsInADepartment : IRunAFeature
  {
    IDisplayInformation display_engine;
    IFindDepartments departments;

    public ViewDeparmentsInADepartment(IDisplayInformation display_engine, IFindDepartments departments)
    {
      this.display_engine = display_engine;
      this.departments = departments;
    }

    public ViewDeparmentsInADepartment():this(new WebFormDisplayEngine(), new StubStoreCatalog())
    {
    }

    public void handle(IProvideRequestDetails request)
    {
      var sub_departments = departments.get_departments_using(request.map<DeparmentsInDepartmentRequest>());
      display_engine.display(sub_departments);
    }
  }
}