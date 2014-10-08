using app.request_handling;
using app.request_handling.aspnet;
using app.stubs;

namespace app.catalog_browsing
{
  public class ViewTheMainDepartmentsInTheStore : IRunAFeature
  {
    IFindDepartments departments;
    IDisplayInformation display_engine;

    public ViewTheMainDepartmentsInTheStore():this(new StubStoreCatalog(),
      new WebFormDisplayEngine())
    {
    }

    public ViewTheMainDepartmentsInTheStore(IFindDepartments departments, IDisplayInformation display_engine)
    {
      this.departments = departments;
      this.display_engine = display_engine;
    }

    public void handle(IProvideRequestDetails request)
    {
      var main_departments = departments.get_the_main_departments();

      display_engine.display(main_departments);
    }
  }
}