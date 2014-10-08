using System;
using System.Web;
using System.Web.Compilation;
using app.request_handling;
using app.request_handling.aspnet;

namespace app.stubs
{
  public class StubRequestHandlingDelegates
  {
    public static ICreateControllerRequestsFromAspNetRequests request_builder = x => new StubRequest();

    class StubRequest : IProvideRequestDetails
    {
      public InputModel map<InputModel>()
      {
        return Activator.CreateInstance<InputModel>();
      }
    }

    public static ICreateTheMissingHandler missing_handler_builder = x =>
    {
      throw new NotImplementedException("There is no handler that can handle this request");
    };

    public static ICreatePageInstances create_page = (path, type) =>
      (IHttpHandler) BuildManager.CreateInstanceFromVirtualPath(path, type);

    public static IGetTheCurrentRequest get_current_request = () => HttpContext.Current;
  }
}