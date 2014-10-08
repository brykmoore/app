namespace app.request_handling
{
  public interface IGetHandlersForRequests
  {
    IHandleOneRequest get_the_handler_that_can_handle(IProvideRequestDetails request);
  }
}