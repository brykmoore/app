using app.constraints;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.request_handling
{  
  [Subject(typeof(ConstrainedFeature))]  
  public class ConstrainedFeatureSpecs
  {
    public abstract class concern : Observes<IRunAFeature,
      ConstrainedFeature>
    {
        
    }

   
    public class when_run : concern
    {
      public class and_its_constraint_is_met
      {
        Establish c = () =>
        {
          request = fake.an<IProvideRequestDetails>();
          original = depends.on<IRunAFeature>();

          depends.on<IEnforceAConstraint>(() => true);
        };

        Because b = () =>
          sut.handle(request);

        It runs_the_original_feature = () =>
          original.received(x => x.handle(request));

        static IRunAFeature original;
        static IProvideRequestDetails request;
      }
        
    }
  }
}
