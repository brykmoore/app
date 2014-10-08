using System;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
      
    }

    public class when_adding : concern
    {
      public class two_positive_numbers
      {
        //Arrange

        //Act
        Because b = () =>
          result = sut.add(2, 3);

        //Assert
        It returns_the_sum = () =>
          result.ShouldEqual(5);

        static int result;
      }

      public class and_either_of_the_arguments_in_negative
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -3));

        It cannot_do_the_addition = () =>
          spec.exception_thrown.ShouldBeAn<ArgumentException>();

      }
    }   
  }
}