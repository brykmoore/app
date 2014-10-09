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

    public class SomeDependency
    {
    }
  }
}