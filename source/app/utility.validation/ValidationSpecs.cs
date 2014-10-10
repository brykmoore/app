using System;
using System.Collections.Generic;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.utility.validation
{
  public class ValidationSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_an_object_is_validated : concern
    {
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

    public static readonly string detailed_breakdown_example = @"

================
TOTAL VOTES
================
5
================
Candidate Breakdown

  Candidate 1
    - Successful Votes (3)
    - Unsuccessful Votes (2)
        
        Vote(1) - Person Name
          -validation errors
          -validation errors
          -validation errors
          -validation errors
          -validation errors

        Vote(2) - Person Name
          -validation errors
          -validation errors
          -validation errors
          -validation errors
          -validation errors


Winner - Candidate Name
";

    public static readonly string voter_information = @"
ID,FirstName,LastName,Birthdate,State,City

1 JP,Boodhoo,  1978-08-27, FL, Orlando 
2,JP2,Boodhoo,  1978-08-27, AZ, Phoenix 
3,John,Doe,  2004-08-27, FL, Orlando 
4,Jane,Doe,  1985-08-27, NY, New York 
";

    public static readonly string candidate_information = @"
ID,Name, Legislator

1,Joe Cool, FL
2,Joe NotSoCool, NY
3,Jane Awesome, OR
";

    public static readonly string votes = @"
VoterId, CandidateId

1,1
2,1
3,1
4,2
5,5
";

  }

    public static readonly string states = @"
ID, Name, Code
1,Arizona, AZ
2,Orlando, OR
3,New York, NY
";

  }
}
