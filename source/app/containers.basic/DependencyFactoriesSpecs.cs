using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.containers.basic
{
  [Subject(typeof(DependencyFactories))]
  public class DependencyFactoriesSpecs
  {
    public abstract class concern : Observes<IGetFactoriesForObjects,
      DependencyFactories>
    {
    }

    public class when_getting_a_factory_for_a_dependency : concern
    {
      public class and_is_has_the_factory
      {
        Establish c = () =>
        {
          the_factory = fake.an<ICreateAnObject>();
        };

        Because b = () =>
          result = sut.get_factory_that_can_create(typeof(AnItemToCreate));

        It returns_the_factory_that_can_create_the_dependency = () =>
          result.ShouldEqual(the_factory);

        static ICreateAnObject result;
        static ICreateAnObject the_factory;
      }
    }

    public class AnItemToCreate
    {
    }
  }
}