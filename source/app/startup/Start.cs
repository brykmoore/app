using System;
using System.IO;
using System.Linq;
using app.containers.core;
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

      public object an(Type type)
      {
        return container.an(type);
      }
    }

    static ICreateStartupSteps create_step_factory ()
    {
      IProvideStartupFeatures startup_features = new StartupService(new LazyContainer());

      return x => (IRunAStartupStep) Activator.CreateInstance(x, startup_features);
    }

    static ICreateStartupSteps step_factory = create_step_factory();

    public static ICreateAStartupPipelineBuilder builder_factory = x =>
    {
      return new StartupPipelineBuilder(step_factory(x), step_factory, RunnableExtensions.combine_with);
    };

    public static ICreateStartupPipelines by<StartupStep>() where StartupStep : IRunAStartupStep
    {
      return builder_factory(typeof(StartupStep));
    }

    public static void by_running_all_steps_in(string file_name)
    {
      File.ReadAllLines(file_name)
          .Select(new TypeNameToTypeClass(typeof(IRunAStartupStep)).map)
          .Select(step_factory.Invoke)
          .each(x => x.run());
    }
  }
}