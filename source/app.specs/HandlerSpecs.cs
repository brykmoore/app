using app.request_handling;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(Handler))]
  public class HandlerSpecs
  {
    public abstract class concern : Observes<IHandleOneRequest,
      Handler>
    {
    }

    public class when_determining_if_it_can_handle_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideRequestDetails>();
        depends.on<IMatchARequest>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });
      };

      Because b = () =>
        result = sut.can_handle(request);

      It decides_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

      static bool result;
      static IProvideRequestDetails request;
    }

    public class when_handling_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideRequestDetails>();
        feature = depends.on<IRunAFeature>();
      };

      Because b = () =>
        sut.handle(request);

      It runs_the_application_feature_with_the_request = () =>
        feature.received(x => x.handle(request));

      static IRunAFeature feature;
      static IProvideRequestDetails request;
    }
  }
}