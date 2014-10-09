namespace app.startup
{
  public interface ICreateStartupPipelines 
  {
    ICreateStartupPipelines then<Step>() where Step : IRunAStartupStep;
    void finish_by<Step>() where Step : IRunAStartupStep;
  }
}