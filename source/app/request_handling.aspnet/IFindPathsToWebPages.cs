namespace app.request_handling.aspnet
{
  public interface IFindPathsToWebPages
  {
    string get_path_to_page_that_displays<Report>();
  }
}