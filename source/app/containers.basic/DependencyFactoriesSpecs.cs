using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.extensions;
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
          factories = Enumerable.Range(1, 100).Select(x => fake.an<ICreateAnObject>()).ToList();

          depends.on<IEnumerable<ICreateAnObject>>(factories);
          factories.Add(the_factory);

          the_factory.setup(x => x.can_create(typeof(AnItemToCreate))).Return(true);
        };

        Because b = () =>
          result = sut.get_factory_that_can_create(typeof(AnItemToCreate));

        It returns_the_factory_that_can_create_the_dependency = () =>
          result.ShouldEqual(the_factory);

        static ICreateAnObject result;
        static ICreateAnObject the_factory;
        static List<ICreateAnObject> factories;
      }

      public class and_it_does_not_have_the_factory
      {
        Establish c = () =>
        {
          the_missing_factory = fake.an<ICreateAnObject>();
          factories = Enumerable.Range(1, 100).Select(x => fake.an<ICreateAnObject>()).ToList();

          depends.on<IEnumerable<ICreateAnObject>>(factories);
          depends.on<ICreateAnObjectFactoryWhenOneCantBeFound>(x =>
          {
            x.ShouldEqual(typeof(AnItemToCreate));
            return the_missing_factory;
          });
        };

        Because b = () =>
          result = sut.get_factory_that_can_create(typeof(AnItemToCreate));

        It returns_the_factory_created_by_the_missing_factory_builder = () =>
          result.ShouldEqual(the_missing_factory);

        static ICreateAnObject result;
        static ICreateAnObject the_missing_factory;
        static List<ICreateAnObject> factories;
      }
    }

    public class AnItemToCreate
    {
    }
  }
}