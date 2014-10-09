using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.startup
{
  [Subject(typeof(Start))]
  public class StartSpecs
  {
    public class SomeTask : IRunAStartupStep
    {
      public void run()
      {
        throw new System.NotImplementedException();
      }
    }

    public abstract class concern : Observes
    {
    }

    public class when_starting_the_pipeline : concern
    {
      Establish c = () =>
      {
        builder = fake.an<ICreateStartupPipelines>();

        ICreateAStartupPipelineBuilder create_builder = x =>
        {
          x.ShouldEqual(typeof(SomeTask));
          return builder;
        };

        spec.change(() => Start.builder_factory).to(create_builder);
      };
      Because b = () =>
        result = Start.by<SomeTask>();

      It provides_access_to_the_startup_pipeline_builder = () =>
        result.ShouldEqual(builder);

      static ICreateStartupPipelines result;
      static ICreateStartupPipelines builder;
    }
  }
}