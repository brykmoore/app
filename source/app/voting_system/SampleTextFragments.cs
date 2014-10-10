namespace app.voting_system
{
  public class SampleTextFragments
  {
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
    public static readonly string states = @"
ID, Name, Code
1,Arizona, AZ
2,Orlando, OR
3,New York, NY
";
  }
}