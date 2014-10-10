using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using app.file_system;
using app.utility;
using developwithpassion.specifications.extensions;
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

    public class when_running_all_of_the_steps_defined_in_an_external_file : concern
    {
      Establish c = () =>
      {
        Type type = typeof(IRunAStartupStep);
        lines = Enumerable.Range(1, 100).Select(x => x.ToString()).ToList();
        a_step = fake.an<IRunAStartupStep>();
        Func<string, Type> type_name_to_type = (type_name) => type;
        file_name = "blah";

        IReadTheLinesInAFile reader = x =>
        {
          x.ShouldEqual(file_name);
          return lines;
        };

        step_factory = (x) =>
        {
          x.ShouldEqual(type);
          return a_step;
        };


        spec.change(() => FileSystem.read_lines_in_file).to(reader);
        spec.change(() => Start.step_factory).to(step_factory);
        spec.change(() => Start.type_name_to_type).to(type_name_to_type);
      };

      Because b = () =>
        Start.by_running_all_steps_in(file_name);

      It runs_each_of_the_steps_created_by_the_factory = () =>
        a_step.received(x => x.run()).Times(100);

      It can_transform_while_iterating = () =>
      {
      };
        

      static string file_name;
      static IEnumerable<string> lines;
      static ICreateStartupSteps step_factory;
      static IRunAStartupStep a_step;
    }
  }
}