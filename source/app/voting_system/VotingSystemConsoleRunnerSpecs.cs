using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using app.file_system;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.voting_system
{
  public class VotingSystemConsoleRunnerSpecs
  {
    public abstract class concern : Observes<VotingSystemRunner>
    {
    }

    public class when_run_with_no_arguments : concern
    {
      Establish c = () =>
      {
        arguments = new string[0];
        interpreter = depends.on<IInterpret>();
      };

      Because b = () =>
        sut.run(arguments);

        It cannot_do_the_interpretation = () =>
            spec.exception_thrown.ShouldBeAn<ArgumentException>();
        It does_not_get_the_arguments = () =>
          interpreter.never_received(x => x.interpret(arguments));
      
      static string[] arguments;
      private static IInterpret interpreter;
    }
  }

    internal interface IInterpret
    {
        List<object> interpret(IEnumerable<string> arguments);
    }

    public class VotingSystemRunner : IRunTheVotingSystem
  {
    public void run(IEnumerable<string> arguments)
    {
      throw new NotImplementedException();
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