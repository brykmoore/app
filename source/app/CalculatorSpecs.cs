﻿using Machine.Specifications;

namespace app
{
  public class CalculatorSpecs
  {
    public class when_adding_two_numbers
    {
      It returns_the_sum = () =>
        Calculator.add(2, 3).ShouldEqual(5);
    }   
  }
}