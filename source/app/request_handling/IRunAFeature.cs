namespace app.request_handling
{
  public interface IRunAFeature
  {
    void handle(IProvideRequestDetails request);
  }
}