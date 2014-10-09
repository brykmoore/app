namespace app.startup
{
  public class StartApplication
  {
    public static void run()
    {
      Start.by<ConfiguringTheContainer>()
        .then<ConfigureFrontController>()
        .finish_by<ConfigureRoutes>();
        
    }
  }
}