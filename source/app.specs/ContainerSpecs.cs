using System;
using app.containers.basic;
using app.containers.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(Container))]
  public class ContainerSpecs
  {
    public abstract class concern : Observes<IGetDependencies,
      Container>
    {
    }

    public class when_getting_a_dependency : concern
    {
      public class non_generically
      {
        Establish c = () =>
        {
          the_dependency = new SomeDependency();
          factory = fake.an<ICreateAnObject>();
          factories = depends.on<IGetFactoriesForObjects>();

          factory.setup(x => x.create()).Return(the_dependency);
          factories.setup(x => x.get_factory_that_can_create(typeof(SomeDependency))).Return(factory);
        };

        Because b = () =>
          result = sut.an(typeof(SomeDependency));

        It returns_the_dependency_created_by_the_factory_for_the_dependency = () =>
          result.ShouldEqual(the_dependency);

        static Object result;
        static SomeDependency the_dependency;
        static ICreateAnObject factory;
        static IGetFactoriesForObjects factories;

      }
      public class and_the_factory_can_create_the_dependency_successfully
      {
        Establish c = () =>
        {
          the_dependency = new SomeDependency();
          factory = fake.an<ICreateAnObject>();
          factories = depends.on<IGetFactoriesForObjects>();

          factory.setup(x => x.create()).Return(the_dependency);
          factories.setup(x => x.get_factory_that_can_create(typeof(SomeDependency))).Return(factory);
        };

        Because b = () =>
          result = sut.an<SomeDependency>();

        It returns_the_dependency_created_by_the_factory_for_the_dependency = () =>
          result.ShouldEqual(the_dependency);

        static SomeDependency result;
        static SomeDependency the_dependency;
        static ICreateAnObject factory;
        static IGetFactoriesForObjects factories;

      }

      public class and_the_factory_creating_the_dependency_throws_fails_to_create
      {
        Establish c = () =>
        {
          factory = fake.an<ICreateAnObject>();
          factories = depends.on<IGetFactoriesForObjects>();
          inner_exception = new Exception();
          custom_exception = new Exception();

          depends.on<ICreateACustomErrorWhenTheDependencyCantBeCreated>((type, e) =>
          {
            type.ShouldEqual(typeof(SomeDependency));
            e.ShouldEqual(inner_exception);
            return custom_exception;
          });

          factory.setup(x => x.create()).Throw(inner_exception);
          factories.setup(x => x.get_factory_that_can_create(typeof(SomeDependency))).Return(factory);
        };

        Because b = () =>
          spec.catch_exception(() => sut.an<SomeDependency>());

        It indicates_that_the_dependency_could_not_be_created = () =>
          spec.exception_thrown.ShouldEqual(custom_exception);

        static ICreateAnObject factory;
        static IGetFactoriesForObjects factories;
        static Exception inner_exception;
        static Exception custom_exception;
      }
    }

    public class SomeDependency
    {
    }
  }
}