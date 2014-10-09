using app.utility;

namespace app.request_handling
{
  public class ConstrainedFeature : IRunAFeature
  {
    IRunAFeature feature;
    IEnforceAConstraint constraint;

    public ConstrainedFeature(IRunAFeature feature, IEnforceAConstraint constraint)
    {
      this.feature = feature;
      this.constraint = constraint;
    }

    public void handle(IProvideRequestDetails request)
    {
      if (constraint()) feature.handle(request);
    }
  }
}