namespace app.startup
{
  public class ConfigureRoutes : IRunAStartupStep
  {
    IProvideStartupFeatures startup;

    public ConfigureRoutes(IProvideStartupFeatures startup)
    {
      this.startup = startup;
    }

    public void run()
    {
    }
  }
}