using System;
using app.containers.core;
using app.utility;

namespace app.startup
{
  public class Start
  {
    class LazyContainer : IGetDependencies
    {
      IGetDependencies container
      {
        get
        {
          return Dependencies.fetch;
        }
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

    public static ICreateAStartupPipelineBuilder builder_factory = x =>
    {
      IProvideStartupFeatures startup_features = new StartupService(new LazyContainer());

      ICreateStartupSteps step_factory = type => (IRunAStartupStep) Activator.CreateInstance(type,startup_features);

      return new StartupPipelineBuilder(step_factory(x), step_factory, RunnableExtensions.combine_with);
    };

    public static ICreateStartupPipelines by<StartupStep>() where StartupStep : IRunAStartupStep
    {
      return builder_factory(typeof(StartupStep));
    }

    public static void by_running_all_steps_in(string file_name)
    {
      throw new NotImplementedException();
    }
  }
}