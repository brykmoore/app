using System;
using System.Data;
using System.Security;
using System.Threading;

namespace app
{
  public interface IPowerDown
  {
    void shut_off();
  }

  public interface ICalculate
  {
    int add(int first, int second);
  }

  public class Calculator : ICalculate, IPowerDown
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
    }

    public int add(int first, int second)
    {
      if (first < 0 || second < 0) throw new ArgumentException();

      using (connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }
      return first + second;
    }

    public void shut_off()
    {
      if (Thread.CurrentPrincipal.IsInRole("blah")) return;

      throw new SecurityException("Not authorized to turn off the calculator");
    }
  }
}