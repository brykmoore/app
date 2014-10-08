namespace app.request_handling
{
  public class HandlerRegistry : IGetHandlersForRequests
  {
    public IHandleOneRequest get_the_handler_that_can_handle(IProvideRequestDetails request)
    {
      throw new System.NotImplementedException();
    }
  }
}