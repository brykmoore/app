using System.Web;
using app.containers.core;

namespace app.request_handling.aspnet
{
  public class AspNetRequestHandler : IHttpHandler
  {
    IHandleAllWebRequests front_controller;
    ICreateControllerRequestsFromAspNetRequests request_factory;

    public AspNetRequestHandler() : this(Dependencies.fetch.an<IHandleAllWebRequests>(),
      Dependencies.fetch.an<ICreateControllerRequestsFromAspNetRequests>())
    {
    }

    public AspNetRequestHandler(IHandleAllWebRequests front_controller,
      ICreateControllerRequestsFromAspNetRequests request_factory)
    {
      this.front_controller = front_controller;
      this.request_factory = request_factory;
    }

    public bool IsReusable
    {
      get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
      front_controller.handle(request_factory(context));
    }
  }
}