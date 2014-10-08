using System;
using app.request_handling;
using app.request_handling.aspnet;

namespace app.stubs
{
  public class StubRequestHandlingDelegates
  {
    public static ICreateControllerRequestsFromAspNetRequests request_builder = x => new StubRequest();

    class StubRequest : IProvideRequestDetails
    {
    }

    public static ICreateTheMissingHandler missing_handler_builder = x =>
    {
      throw new NotImplementedException("There is no handler that can handle this request");
    };
  }
}