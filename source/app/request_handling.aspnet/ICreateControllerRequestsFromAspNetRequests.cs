using System.Web;

namespace app.request_handling.aspnet
{
  public delegate IProvideRequestDetails ICreateControllerRequestsFromAspNetRequests(HttpContext request);
}