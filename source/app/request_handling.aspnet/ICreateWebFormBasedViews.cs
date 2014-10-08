using System.Web;

namespace app.request_handling.aspnet
{
  public interface ICreateWebFormBasedViews
  {
    IHttpHandler create_view_to_display<Report>(Report report);
  }
}