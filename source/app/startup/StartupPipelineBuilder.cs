using System;
using app.utility;

namespace app.startup
{
  public class StartupPipelineBuilder : ICreateStartupPipelines
  {
    public IRunnable step;
    public ICreateStartupSteps step_factory;
    public ICombineCommands combine_commands;

    public StartupPipelineBuilder(IRunnable step, ICreateStartupSteps step_factory,
      ICombineCommands combine_commands)
    {
      this.step = step;
      this.step_factory = step_factory;
      this.combine_commands = combine_commands;
    }

    IRunnable combine_with(Type step)
    {
      return combine_commands(this.step, step_factory(step));
    }

    IRunnable combine_with<Step>() where Step : IRunAStartupStep
    {
      return combine_with(typeof(Step));
    }

    public ICreateStartupPipelines then<Step>() where Step : IRunAStartupStep
    {
      return new StartupPipelineBuilder(combine_with<Step>(), step_factory, combine_commands);
    }

    public void finish_by<Step>() where Step : IRunAStartupStep
    {
      combine_with<Step>().run();
    }
  }
}