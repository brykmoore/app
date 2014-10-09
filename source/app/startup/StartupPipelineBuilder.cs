namespace app.startup
{
  public class StartupPipelineBuilder : ICreateStartupPipelines
  {
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