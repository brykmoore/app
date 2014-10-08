using System.Web;
using app.request_handling;
using app.request_handling.aspnet;
using app.specs.test_utilities;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayInformation,
      WebFormDisplayEngine>
    {
    }

    public class when_displaying_information : concern
    {
      Establish c = () =>
      {
        some_report = new SomeReport();
        view_factory = depends.on<ICreateWebFormBasedViews>();
        current_request = ObjectFactory.web.create_http_context();
        depends.on<IGetTheCurrentRequest>(() => current_request);
        view = fake.an<IHttpHandler>();

        view_factory.setup(x => x.create_view_to_display(some_report)).Return(view);
      };

      Because b = () =>
        sut.display(some_report);

      It tells_the_view_to_render_using_the_current_request = () =>
        view.received(x => x.ProcessRequest(current_request));

      static SomeReport some_report;
      static ICreateWebFormBasedViews view_factory;
      static IHttpHandler view;
      static HttpContext current_request;
    }
  }

  public class SomeReport
  {
  }
}