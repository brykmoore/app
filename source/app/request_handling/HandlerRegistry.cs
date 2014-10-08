using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace app.request_handling
{
  public class HandlerRegistry : IGetHandlersForRequests
  {
      IEnumerable<IHandleOneRequest> all_the_handlers;
      public HandlerRegistry(IEnumerable<IHandleOneRequest> all_the_handlers)
      {
          this.all_the_handlers = all_the_handlers;
      }

      public IHandleOneRequest get_the_handler_that_can_handle(IProvideRequestDetails request)
      {
          var handler = all_the_handlers.Single(x => x.can_handle(request));
          return handler;
      }
  }
}