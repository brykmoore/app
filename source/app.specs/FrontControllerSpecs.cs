using app.request_handling;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(FrontController))]
  public class FrontControllerSpecs
  {
    public abstract class concern : Observes<IHandleAllWebRequests,
      FrontController>
    {
    }

    public class when_handling_a_request : concern
    {
      Establish c = () =>
      {
        handler_that_can_process = fake.an<IHandleOneRequest>();
        request = fake.an<IProvideRequestDetails>();
        handler_registry = depends.on<IGetHandlersForRequests>();

        handler_registry.setup(x => x.get_the_handler_that_can_handle(request)).Return(handler_that_can_process);
      };

      Because b = () =>
        sut.handle(request);

      It delegates_the_handling_of_the_request_to_the_handler_that_can_process_the_request = () =>
        handler_that_can_process.received(x => x.handle(request));

      static IHandleOneRequest handler_that_can_process;
      static IProvideRequestDetails request;
      static IGetHandlersForRequests handler_registry;
    }
  }
}