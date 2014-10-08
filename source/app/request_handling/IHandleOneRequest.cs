namespace app.request_handling
{
  public interface IHandleOneRequest
  {
    void handle(IProvideRequestDetails request);
    bool can_handle(IProvideRequestDetails request);
  }
}