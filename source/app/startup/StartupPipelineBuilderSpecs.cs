﻿using app.utility;
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
        second_step = depends.on<IRunAStartupStep>();
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

      It returns_a_new_pipeline_builder_with_the_combined_step_as_its_initial_step = () =>
      {
        var builder = result.ShouldBeAn<StartupPipelineBuilder>();
        builder.initial_step.ShouldEqual(combined_step);
        builder.step_factory.ShouldEqual(step_factory);
      };

      static ICreateStartupPipelines result;
      static IRunnable combined_step;
      static IRunAStartupStep second_step;
      static IRunnable first_step;
      static ICreateStartupSteps step_factory;
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