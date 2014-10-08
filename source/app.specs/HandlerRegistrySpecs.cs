using System.Collections.Generic;
using System.Linq;
using app.request_handling;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{  
  [Subject(typeof(HandlerRegistry))]  
  public class HandlerRegistrySpecs
  {
    public abstract class concern : Observes<IGetHandlersForRequests,
      HandlerRegistry>
    {
        
    }

   
    public class when_getting_a_handler_for_a_request : concern
    {

      public class and_it_has_the_handler
      {
        Establish c = () =>
        {
          the_handler_that_can_handle = fake.an<IHandleOneRequest>();
          request = fake.an<IProvideRequestDetails>();

          all_the_handlers = Enumerable.Range(1, 100).Select(x => fake.an<IHandleOneRequest>()).ToList();
          all_the_handlers.Add(the_handler_that_can_handle);

          the_handler_that_can_handle.setup(x => x.can_handle(request)).Return(true);

          depends.on<IEnumerable<IHandleOneRequest>>(all_the_handlers);
        };

        Because b = () =>
          result = sut.get_the_handler_that_can_handle(request);

        It returns_the_handler_to_the_caller = () =>
          result.ShouldEqual(the_handler_that_can_handle);

        static IHandleOneRequest result;
        static IHandleOneRequest the_handler_that_can_handle;
        static IProvideRequestDetails request;
        static List<IHandleOneRequest> all_the_handlers;
      }
        
      public class and_it_does_not_have_the_handler
      {
        Establish c = () =>
        {
          request = fake.an<IProvideRequestDetails>();

          all_the_handlers = Enumerable.Range(1, 100).Select(x => fake.an<IHandleOneRequest>()).ToList();
          missing_handler = fake.an<IHandleOneRequest>();

          depends.on<IEnumerable<IHandleOneRequest>>(all_the_handlers);
          depends.on<ICreateTheMissingHandler>(x =>
          {
            x.ShouldEqual(request);
            return missing_handler;
          });
        };

        Because b = () =>
          result = sut.get_the_handler_that_can_handle(request);

        It returns_the_handler_created_by_the_missing_handler_builder = () =>
          result.ShouldEqual(missing_handler);

        static IHandleOneRequest result;
        static IProvideRequestDetails request;
        static List<IHandleOneRequest> all_the_handlers;
        static IHandleOneRequest missing_handler;
      }
    }
  }
}
