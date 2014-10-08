using System.Web;
using app.request_handling.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(WebFormFactory))]
  public class WebFormFactorySpecs
  {
    public abstract class concern : Observes<ICreateWebFormBasedViews,
      WebFormFactory>
    {
    }

    public class when_creating_a_webform_to_display_a_report : concern
    {
      Establish c = () =>
      {
        report = new AReport();
        the_view = fake.an<IDisplayA<AReport>>();
        path_registry = depends.on<IFindPathsToWebPages>();
        page_path = "blah.aspx";

        path_registry.setup(x => x.get_path_to_page_that_displays<AReport>()).Return(page_path);

        depends.on<ICreatePageInstances>((path, type) =>
        {
          path.ShouldEqual(page_path);
          type.ShouldEqual(typeof(IDisplayA<AReport>));
          return the_view;
        });
      };

      Because b = () =>
        result = sut.create_view_to_display(report);

      It returns_the_created_page_instance = () =>
        result.ShouldEqual(the_view);

      It populates_the_view_with_its_report = () =>
        the_view.report.ShouldEqual(report);

      static IFindPathsToWebPages path_registry;
      static AReport report;
      static IHttpHandler result;
      static IDisplayA<AReport> the_view;
      static string page_path;
    }

    public class AReport
    {
    }
  }
}