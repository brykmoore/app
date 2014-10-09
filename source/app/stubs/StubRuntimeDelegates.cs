using System;
using System.Web;
using System.Web.Compilation;
using app.containers.basic;
using app.request_handling;
using app.request_handling.aspnet;

namespace app.stubs
{
  public class StubRuntimeDelegates
  {
    public class startup
    {
      public static ICreateAnObjectFactoryWhenOneCantBeFound create_missing_dependency_factory = x =>
      {
        throw new NotImplementedException(string.Format("There is no factory that can create a: {0}", x.FullName));
      };

      public static ICreateACustomErrorWhenTheDependencyCantBeCreated create_dependency_error_builder = (type, inner) =>
      {
        throw new NotImplementedException(string.Format("There was an error creating the type: {0}", type.FullName), inner);
      };
    }

    public class containers
    {
      public static IMatchAType is_instance_of<Contract>()
      {
        return x => x.IsAssignableFrom(typeof(Contract));
      }
    }

    public class web
    {
      public static ICreateControllerRequestsFromAspNetRequests request_builder = x => new StubRequest();

      public static ICreateTheMissingHandler missing_handler_builder = x =>
      {
        throw new NotImplementedException("There is no handler that can handle this request");
      };

      public static ICreatePageInstances create_page = (path, type) =>
        (IHttpHandler) BuildManager.CreateInstanceFromVirtualPath(path, type);

      public static IGetTheCurrentRequest get_current_request = () => HttpContext.Current;

      class StubRequest : IProvideRequestDetails
      {
        public InputModel map<InputModel>()
        {
          return Activator.CreateInstance<InputModel>();
        }
      }
    }
  }
}