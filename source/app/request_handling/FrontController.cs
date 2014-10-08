namespace app.request_handling
{
  public class FrontController : IHandleAllWebRequests
  {
    public IGetHandlersForRequests handler_registry;

    public FrontController(IGetHandlersForRequests handler_registry)
    {
      this.handler_registry = handler_registry;
    }

    public FrontController() : this(new HandlerRegistry())
    {
    }

    public void handle(IProvideRequestDetails request)
    {
      var handler = handler_registry.get_the_handler_that_can_handle(request);
      handler.handle(request);
    }
  }
}