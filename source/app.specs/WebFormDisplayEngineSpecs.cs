using app.request_handling;
using app.request_handling.aspnet;
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
      };

      Because b = () =>
        sut.display(some_report);

      It OBSERVATION_NAME = () => 

      static SomeReport some_report;
    }
  }

  public class SomeReport
  {
  }
}