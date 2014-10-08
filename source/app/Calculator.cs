using System;
using System.Data;

namespace app
{
  public class Calculator
  {
      IDbConnection connection;
      public Calculator(IDbConnection connection)
      {
          this.connection = connection;
      }

      public int add(int first, int second)
    {
          connection.Open();
      if (first < 0 || second < 0) throw new ArgumentException();
      return first + second;
    }
  }
}