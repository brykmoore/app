using System.Data;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.containers.basic
{
  [Subject(typeof(ObjectFactory))]
  public class ObjectFactorySpecs
  {
    public abstract class concern : Observes<ICreateAnObject,
      ObjectFactory>
    {
    }

    public class when_determining_if_it_can_create_an_object : concern
    {
      Establish c = () =>
      {
        depends.on<IMatchAType>(x => true);
      };

      Because b = () =>
        result = sut.can_create(typeof(IDbConnection));

      It makes_it_determination_by_using_its_specification = () =>
        result.ShouldBeTrue();

      static bool result;
    }

    public class when_creating_an_object : concern
    {
      Establish c = () =>
      {
        real_factory = depends.on<ICreateOneObject>();
        real_factory.setup(x => x.create()).Return(42);
      };

      Because b = () =>
        result = sut.create();

      It returns_the_result_of_using_its_factory_strategy = () =>
        result.ShouldEqual(42);

      static object result;
      static ICreateOneObject real_factory;
    }
  }
}