using System.Collections.Generic;
using app.request_handling;
using app.request_handling.aspnet;
using app.stubs;

namespace app.startup
{
  public class ConfigureFrontController : IRunAStartupStep
  {
    IProvideStartupFeatures startup;

    public ConfigureFrontController(IProvideStartupFeatures startup)
    {
      this.startup = startup;
    }

    public void run()
    {
      startup.register<IHandleAllWebRequests, FrontController>();
      startup.register<IGetHandlersForRequests, HandlerRegistry>();
      startup.register<IEnumerable<IHandleOneRequest>, StubHandlers>();
      startup.register<IDisplayInformation, WebFormDisplayEngine>();
      startup.register<ICreateWebFormBasedViews, WebFormFactory>();
      startup.register<IFindPathsToWebPages, StubPathRegistry>();

      startup.register(StubRuntimeDelegates.web.create_page);
      startup.register(StubRuntimeDelegates.web.missing_handler_builder);
      startup.register(StubRuntimeDelegates.web.request_builder);
      startup.register(StubRuntimeDelegates.web.get_current_request);
    } 
  }
}
