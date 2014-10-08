namespace app.request_handling
{
  public class Handler : IHandleOneRequest
  {
    IMatchARequest request_matcher;
    IRunAFeature feature;

    public Handler(IMatchARequest request_matcher, IRunAFeature feature)
    {
      this.request_matcher = request_matcher;
      this.feature = feature;
    }

    public bool can_handle(IProvideRequestDetails request)
    {
      return request_matcher(request);
    }

    public void handle(IProvideRequestDetails request)
    {
      feature.handle(request);
    }
  }
}