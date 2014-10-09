using System;

namespace app.startup
{
  public class Start
  {
    public static ICreateAStartupPipelineBuilder builder_factory = x =>
    {
      throw new NotImplementedException("Overwrite later");
    };

    public static ICreateStartupPipelines by<StartupStep>() where StartupStep : IRunAStartupStep
    {
      return builder_factory(typeof(StartupStep));
    }
  }
}