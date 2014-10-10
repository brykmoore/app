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

      It can_cache_values_for_methods_that_have_already_been_called = () =>
      {
        var times_invoked = 0;

        Func<int, int, int> addition = (x, y) =>
        {
          times_invoked++;
          return x + y;
        };

        var add_to_2 = addition.curry(2);

        var cached_addition = addition.memoize();
        cached_addition(3, 3).ShouldEqual(6);
        cached_addition(3, 3).ShouldEqual(6);
        cached_addition(3, 3).ShouldEqual(6);
        cached_addition(4, 7).ShouldEqual(11);
        cached_addition(4, 7).ShouldEqual(11);
        cached_addition(4, 7).ShouldEqual(11);
        cached_addition(4, 7).ShouldEqual(11);
        cached_addition(8, 5).ShouldEqual(13);

        times_invoked.ShouldEqual(3);
      }; 

      It can_build_up_methods_dynamically_by_using_expression_trees = () =>
      {
        Func<int, bool> even = x => x%2 == 0;
        even(2).ShouldBeTrue();

        var number_2 = Expression.Constant(2);
        var zero = Expression.Constant(0);
        var parameter = Expression.Parameter(typeof(int), "x");

        var dynamic_even_expression = Expression.Lambda<Func<int, bool>>(null, null);
        var dynamic_even = dynamic_even_expression.Compile();

        dynamic_even(2).ShouldBeTrue();
      }; 
    }
  }
}