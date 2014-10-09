using System.Web;
using app.test_utilities;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.request_handling.aspnet
{  
  [Subject(typeof(AspNetRequestHandler))]  
  public class AspNetRequestHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
      AspNetRequestHandler>
    {
        
    }
   
    public class when_processing_a_new_http_context_based_request : concern
    {
      Establish c = () =>
      {
        a_aspnet_based_request = ObjectFactory.web.create_http_context();
        front_controller = depends.on<IHandleAllWebRequests>();
        a_new_controller_request = fake.an<IProvideRequestDetails>();

        depends.on<ICreateControllerRequestsFromAspNetRequests>(x =>
        {
          x.ShouldEqual(a_aspnet_based_request);
          return a_new_controller_request;
        });
      };

      Because b = () =>
        sut.ProcessRequest(a_aspnet_based_request);

      It delegates_procesing_of_a_new_controller_request_to_our_front_controller = () =>
        front_controller.received(x => x.handle(a_new_controller_request));

      static IHandleAllWebRequests front_controller;
      static IProvideRequestDetails a_new_controller_request;
      static HttpContext a_aspnet_based_request;
    }
  }
}
