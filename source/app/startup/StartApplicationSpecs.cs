using System;
using app.containers.core;
using app.request_handling;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.startup
{
  [Subject(typeof(StartApplication))]
  public class StartApplicationSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class after_the_application_startup_process_has_run : concern
    {
      Because b = () =>
        StartApplication.run();

      It key_application_services_and_features_should_be_available = () =>
      {
        Console.Out.WriteLine("Hey There");
        Dependencies.fetch.an<IHandleAllWebRequests>().ShouldBeAn<FrontController>();
      };
    }
  }
}