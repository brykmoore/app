using System;
using System.Web;

namespace app.request_handling.aspnet
{
  public delegate IHttpHandler ICreatePageInstances(
  string path_to_page, Type page);
}