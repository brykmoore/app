using System;
using System.Collections.Generic;
using System.Linq;
using app.containers.core;
using app.file_system;
using app.reflection;
using app.utility;

namespace app.startup
{
  public class Start
  {
    class LazyContainer : IGetDependencies
    {
      IGetDependencies container
      {
        get { return Dependencies.fetch; }
      }

      public Dependency an<Dependency>()
      {
        return container.an<Dependency>();
      }

      public IEnumerable<object> all(Type dependency_type)
      {
        return container.all(dependency_type);
      }

      public IEnumerable<Dependency> all<Dependency>()
      {
        return container.all<Dependency>();
      }

      public object an(Type type)
      {
        return container.an(type);
      }
    }

    public static ICreateStartupSteps step_factory = create_step_factory();
    public static Func<string, Type> type_name_to_type = new TypeNameToTypeClass().map;

    static ICreateStartupSteps create_step_factory()
    {
      IProvideStartupFeatures startup_features = new StartupService(new LazyContainer());

      return x => (IRunAStartupStep) Activator.CreateInstance(x, startup_features);
    }

    public static ICreateAStartupPipelineBuilder builder_factory = x =>
    {
      return new StartupPipelineBuilder(step_factory(x), step_factory, RunnableExtensions.combine_with);
    };

    public static ICreateStartupPipelines by<StartupStep>() where StartupStep : IRunAStartupStep
    {
      return builder_factory(typeof(StartupStep));
    }

    public static void by_running_only<StartupStep>() where StartupStep : IRunAStartupStep
    {
      step_factory(typeof(StartupStep)).run();
    }

    public static void by_running_all_steps_in(string file_name)
    {
      FileSystem.read_lines_in_file(file_name)
        .Select(type_name_to_type.Invoke)
        .Select(step_factory.Invoke)
        .each(x => x.run());
    }
  }
}