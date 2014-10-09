namespace app.startup
{
  public class StartupPipelineBuilder : ICreateStartupPipelines
  {
    public IRunAStartupStep initial_step;
    public ICreateStartupSteps step_factory;

    public void finish_by<Step>() where Step : IRunAStartupStep
    {
      throw new System.NotImplementedException();
    }

    public ICreateStartupPipelines then<Step>() where Step : IRunAStartupStep
    {
      throw new System.NotImplementedException();
    }
  }
}