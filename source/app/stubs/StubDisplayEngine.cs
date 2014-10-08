using System;
using System.Collections.Generic;
using System.Web;
using app.catalog_browsing;
using app.request_handling;

namespace app.stubs
{
  public class StubDisplayEngine : IDisplayInformation
  {
    public void display<ReportModel>(ReportModel report)
    {
      var view = typeof(ReportModel) == typeof(IEnumerable<DepartmentLineItem>) ? "DepartmentBrowser" : "ProductBrowser";

      HttpContext.Current.Items.Add("report", report);
      HttpContext.Current.Server.Transfer(String.Format("~/views/{0}.aspx", view));

    }
  }
}