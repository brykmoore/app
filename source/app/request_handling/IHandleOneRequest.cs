namespace app.request_handling
{
  public interface IHandleOneRequest : IRunAFeature
  {
    bool can_handle(IProvideRequestDetails request);
  }
}