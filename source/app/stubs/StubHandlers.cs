using System;
using System.Collections;
using System.Collections.Generic;
using app.catalog_browser.queries;
using app.catalog_browsing;
using app.request_handling;

namespace app.stubs
{
  public class StubHandlers : IEnumerable<IHandleOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IHandleOneRequest> GetEnumerator()
    {
      yield return create_handler_to_view<IEnumerable<DepartmentLineItem>, GetTheMainDepartments>();
      yield return create_handler_to_view<IEnumerable<DepartmentLineItem>, GetDepartmentsInDepartment>();
      yield return create_handler_to_view<IEnumerable<ProductSummaryLine>, GetProductsInDepartment>();
    }

    IHandleOneRequest create_handler_to_view<Report>(IFetchAReport<Report> query)
    {
//      return new Handler(x => true, new ViewReport<Report>(query));
      throw new NotImplementedException();
    }

    IHandleOneRequest create_handler_to_view<Report, Query>() where Query : IFetchA<Report>, new()
    {
      return create_handler_to_view(new Query().fetch_using);
    }
  }
}