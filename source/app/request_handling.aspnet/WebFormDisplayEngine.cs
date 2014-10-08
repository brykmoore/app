using app.stubs;

namespace app.request_handling.aspnet
{
  public class WebFormDisplayEngine : IDisplayInformation
  {
    ICreateWebFormBasedViews view_factory;
    IGetTheCurrentRequest current_request;

    public WebFormDisplayEngine():this(new WebFormFactory(),
      StubRequestHandlingDelegates.get_current_request)
    {
    }

    public WebFormDisplayEngine(ICreateWebFormBasedViews view_factory, IGetTheCurrentRequest current_request)
    {
      this.view_factory = view_factory;
      this.current_request = current_request;
    }

    public void display<ReportModel>(ReportModel report)
    {
      var view = view_factory.create_view_to_display(report);
      view.ProcessRequest(current_request());
    }
  }
}