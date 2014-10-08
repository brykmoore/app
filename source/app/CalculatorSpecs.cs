using System;
using System.Data;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      protected static IDbConnection connection;
    }

    public class when_created : concern
    {
      It does_not_open_its_database_connection = () =>
        connection.never_received(x => x.Open());
    }

    public class when_adding : concern
    {
      public class two_positive_numbers
      {
        //Arrange
        Establish c = () =>
        {
          command = fake.an<IDbCommand>();   

          connection.setup(x => x.CreateCommand()).Return(command);
        };

        //Act
        Because b = () =>
          result = sut.add(2, 3);

        //Assert
        It returns_the_sum = () =>
          result.ShouldEqual(5);

        It opens_a_connection_to_the_database = () =>
          connection.received(x => x.Open());

        It run_a_query = () =>
          command.received(x => x.ExecuteNonQuery());

        static int result;
        static IDbCommand command;
      }

      public class and_either_of_the_arguments_in_negative
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -3));

        It cannot_do_the_addition = () =>
          spec.exception_thrown.ShouldBeAn<ArgumentException>();

        It does_not_open_the_connection = () =>
          connection.never_received(x => x.Open());
          

      }
    }   
  }
}