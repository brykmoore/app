using app.request_handling.aspnet;

namespace app.request_handling
{
  public class ViewReport<Report> : IRunAFeature
  {
    IFetchAReport<Report> query;
    IDisplayInformation display_engine;

    public ViewReport(IFetchAReport<Report> query, IDisplayInformation display_engine)
    {
      this.query = query;
      this.display_engine = display_engine;
    }

    public ViewReport(IFetchAReport<Report> query):this(query, new WebFormDisplayEngine())
    {
    }

    public ViewReport(IFetchA<Report> query):this(query.fetch_using)
    {
    }

    public void handle(IProvideRequestDetails request)
    {
      display_engine.display(query(request));
    }
  }
}