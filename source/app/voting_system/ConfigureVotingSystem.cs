using app.startup;

namespace app.voting_system
{
  public class ConfigureVotingSystem : IRunAStartupStep
  {
    IProvideStartupFeatures startup;

    public ConfigureVotingSystem(IProvideStartupFeatures startup)
    {
      this.startup = startup;
    }

    public void run()
    {
      startup.register<IRunTheVotingSystem,VotingSystemRunner>();
    }
  }
}