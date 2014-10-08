namespace app.request_handling
{
  public interface IHandleAllWebRequests
  {
    void handle(IProvideRequestDetails request);
  }
}