using System.Web.Hosting;
using app.containers.core;

namespace app.containers.basic
{
  public class Container : IGetDependencies
  {
      IGetFactoriesForObjects factories;

      public Container(IGetFactoriesForObjects factories)
      {
          this.factories = factories;
      }

      public Dependency an<Dependency>()
      {
          var factory =factories.get_factory_that_can_create(typeof(Dependency));
          return (Dependency)factory.create();
      }


  }
}