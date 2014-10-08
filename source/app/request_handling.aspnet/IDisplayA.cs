using System.Web;
using System.Web.UI;

namespace app.request_handling.aspnet
{
  public interface IDisplayA<Report> : IHttpHandler
  {
    Report report { get; set; }
  }

  public class ViewFor<Report> : Page, IDisplayA<Report>
  {
    public Report report { get; set; }
  }
}