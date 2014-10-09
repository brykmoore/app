using System;

namespace app.containers.core
{
  public class Dependencies
  {
    public static IProvideAccessToTheContainerConfiguredAtStartup access_the_container = () =>
    {
      throw new NotImplementedException("This needs to be overwritten by a startup process");
    };

    public static IGetDependencies fetch
    {
      get
      {
        return access_the_container();
      }
    }
  }
}