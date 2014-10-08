using System.Web;
using app.stubs;

namespace app.request_handling.aspnet
{
  public class WebFormFactory : ICreateWebFormBasedViews
  {
    IFindPathsToWebPages page_paths;
    ICreatePageInstances page_factory;

    public WebFormFactory(IFindPathsToWebPages page_paths, ICreatePageInstances page_factory)
    {
      this.page_paths = page_paths;
      this.page_factory = page_factory;
    }

    public WebFormFactory():this(new StubPathRegistry(), StubRequestHandlingDelegates.create_page)
    {
    }

    public IHttpHandler create_view_to_display<Report>(Report report)
    {
      var path = page_paths.get_path_to_page_that_displays<Report>();
      var view = (IDisplayA<Report>)page_factory(path, typeof(IDisplayA<Report>));
      view.report = report;
      return view;
    }
  }
}