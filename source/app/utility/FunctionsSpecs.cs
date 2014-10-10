using System;
using System.Linq.Expressions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.utility
{
  [Subject(typeof(Expression))]
  public class FunctionsSpecs
  {
    public abstract class concern : Observes 
    {
    }

    public class when_messing_around_with_functions : concern
    {
      It can_compose_higher_order_functions = () =>
      {
        Func<int, int, int> addition = (x, y) => x + y;
        Func<int, int> add_5_to_a_number = addition.curry(5);

        addition(2, 3).ShouldEqual(5);
        add_5_to_a_number(8).ShouldEqual(13);
      }; 
    }
  }
}