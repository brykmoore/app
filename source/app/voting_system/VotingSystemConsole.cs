using app.containers.core;
using app.startup;

namespace app.voting_system
{
  public class VotingSystemConsole
  {
    public static void main(string[] args)
    {
      Start.by_running_only<ConfigureVotingSystem>();

      Dependencies.fetch.an<IRunTheVotingSystem>().run(args);
    } 
  }
}