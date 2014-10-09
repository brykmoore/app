using app.containers.core;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(Dependencies))]
  public class DependenciesSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_providing_access_to_the_container_facade : concern
    {
      Establish c = () =>
      {
        the_container_facade = fake.an<IGetDependencies>();
        IProvideAccessToTheContainerConfiguredAtStartup startup = () => the_container_facade;

        spec.change(() => Dependencies.access_the_container).to(startup);
      };

      Because b = () =>
        result = Dependencies.fetch;

      It returns_the_container_facade_configured_at_startup = () =>
        result.ShouldEqual(the_container_facade);

      static IGetDependencies result;
      static IGetDependencies the_container_facade;
    }
  }
}