using app.utility;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.startup
{
  [Subject(typeof(StartupPipelineBuilder))]
  public class StartupPipelineBuilderSpecs
  {
    public abstract class concern : Observes<ICreateStartupPipelines,
      StartupPipelineBuilder>
    {
    }

    public class when_followed_by_another_step : concern
    {
      Establish c = () =>
      {
        first_step = depends.on<IRunnable>();
        second_step = fake.an<IRunAStartupStep>();
        combined_step = fake.an<IRunnable>();

        depends.on<ICombineCommands>((x, y) =>
        {
          x.ShouldEqual(first_step);
          y.ShouldEqual(second_step);
          return combined_step;
        });

        step_factory = depends.on<ICreateStartupSteps>(x =>
        {
          x.ShouldEqual(typeof(NextStep));
          return second_step;
        });
      };

      Because b = () =>
        result = sut.then<NextStep>();

      It returns_a_new_pipeline_builder = () =>
        result.ShouldBeAn<StartupPipelineBuilder>().ShouldNotEqual(sut);

      It returned_pipeline_builders_step_is_the_combined_step = () =>
        result.ShouldBeAn<StartupPipelineBuilder>().step.ShouldEqual(combined_step);

      It returned_pipeline_builders_step_factory_is_correct = () =>
        result.ShouldBeAn<StartupPipelineBuilder>().step_factory.ShouldEqual(step_factory);

        

      static ICreateStartupPipelines result;
      static IRunnable combined_step;
      static IRunAStartupStep second_step;
      static IRunnable first_step;
      static ICreateStartupSteps step_factory;
    }

    public class when_the_final_step_is_provided : concern
    {
      Establish c = () =>
      {
        first_step = depends.on<IRunnable>();
        final_step = fake.an<IRunAStartupStep>();
        combined_step = fake.an<IRunnable>();

        depends.on<ICombineCommands>((x, y) =>
        {
          x.ShouldEqual(first_step);
          y.ShouldEqual(final_step);
          return combined_step;
        });

        depends.on<ICreateStartupSteps>(x =>
        {
          x.ShouldEqual(typeof(NextStep));
          return final_step;
        });
      };

      Because b = () =>
        sut.finish_by<NextStep>();

      It runs_the_combined_steps = () =>
        combined_step.received(x => x.run());
        

      static IRunnable combined_step;
      static IRunAStartupStep final_step;
      static IRunnable first_step;
    }

    public class NextStep : IRunAStartupStep
    {
      public void run()
      {
        throw new System.NotImplementedException();
      }
    }
  }
}