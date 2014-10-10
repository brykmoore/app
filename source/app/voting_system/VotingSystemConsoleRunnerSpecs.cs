using System.Collections.Generic;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.voting_system
{
  public class VotingSystemConsoleRunnerSpecs
  {
    public abstract class concern : Observes<VotingSystemRunner>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        arguments = new string[0];
      };

      Because b = () =>
        sut.run(arguments);


      static string[] arguments;
    }
  }

  public class VotingSystemRunner : IRunTheVotingSystem
  {
    public void run(IEnumerable<string> arguments)
    {
      throw new System.NotImplementedException();
    }
  }

  public interface IRunTheVotingSystem
  {
    void run(IEnumerable<string> arguments);
  }

  /*Automated Voting System
     * 
    /* Voting validation requirements
     *  - Person needs to have first and last name
     *  - Person needs to have a valid address
     *     - city
     *     - state
     *  - Person needs to be at least 18 years old to vote
     *  - Can only vote for a candidate who has legislation over the state they live in
     *
     * 
     * Program Requirements
     * 
     *  - Voters and candidates need to be able to be read in externally
     *  - Votes are read in externally and submitted into the voting system
     *  - Once all votes are submitted should be able to output a detailed breakdown
     *    of the following:
     *    
     *      - How many successful votes each candidate received
     *      - How many illegitimate votes that were received
     *      
     *      - For each of the votes that was not successful, want to see a breakdown of the following:
     *        - The name of the voter who cast an invalid vote
     *        - The "errors" that were present for that vote
     *        
     * 
     * 
     */
}

}