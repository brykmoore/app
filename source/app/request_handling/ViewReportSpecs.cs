using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.request_handling
{
  [Subject(typeof(ViewReport<>))]
  public class ViewReportSpecs
  {
    public abstract class concern : Observes<IRunAFeature,
      ViewReport<MyReport>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideRequestDetails>();
        display_engine = depends.on<IDisplayInformation>();
        the_report = new MyReport();
        depends.on<IFetchAReport<MyReport>>(x =>
        {
          x.ShouldEqual(request);
          return the_report;
        });
      };

      Because b = () =>
        sut.handle(request);

      It displays_the_report_found_using_its_query = () =>
        display_engine.received(x => x.display(the_report));

      static IProvideRequestDetails request;
      static IDisplayInformation display_engine;
      static MyReport the_report;
    }
  }

  public class MyReport
  {
  }
}