using System;
using System.Collections.Generic;
using app.catalog_browsing;
using app.request_handling.aspnet;

namespace app.stubs
{
  public class StubPathRegistry : IFindPathsToWebPages
  {
    public string get_path_to_page_that_displays<Report>()
    {
      var views = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<DepartmentLineItem>), "DepartmentBrowser"},
        {typeof(IEnumerable<ProductSummaryLine>), "ProductBrowser"}
      };

      if (views.ContainsKey(typeof(Report))) return string.Format("~/views/{0}.aspx",views[typeof(Report)]);

      throw new System.NotImplementedException("There is no view that can display your report");
    }
  }
}