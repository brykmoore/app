using System.Collections.Generic;
using System.Linq;

namespace app.request_handling
{
  public class HandlerRegistry : IGetHandlersForRequests
  {
    IEnumerable<IHandleOneRequest> all_the_handlers;
    ICreateTheMissingHandler missing_handler_builder;

    public HandlerRegistry(IEnumerable<IHandleOneRequest> all_the_handlers,
      ICreateTheMissingHandler missing_handler_builder)
    {
      this.all_the_handlers = all_the_handlers;
      this.missing_handler_builder = missing_handler_builder;
    }

    public IHandleOneRequest get_the_handler_that_can_handle(IProvideRequestDetails request)
    {
      var handler = all_the_handlers.FirstOrDefault(x => x.can_handle(request)) ?? missing_handler_builder(request);
      return handler;
    }
  }
}