using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Rhino.Mocks;

namespace app
{
  public class CalculatorSpecs
  {
    public abstract class calculation_concerns : Observes<ICalculate, Calculator>
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      protected static IDbConnection connection;
    }

    public abstract class power_concerns : Observes<IPowerDown, Calculator>
    {
    }

    public class when_shutting_off_the_calculator : power_concerns
    {
      public class and_they_are_in_the_correct_security_role
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          sut.shut_off();

        It allows_them_to_shut_it_off = () =>
        {
        };

        static IPrincipal principal;
      }

      public class and_they_are_not_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          spec.catch_exception(() => sut.shut_off());

        It does_not_allow_them_to_turn_it_off = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();

        static IPrincipal principal;
      }
    }

    public class when_created : calculation_concerns
    {
      It does_not_open_its_database_connection = () =>
        connection.never_received(x => x.Open());
    }

    public class when_adding : calculation_concerns
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