using System;
using System.IO;

namespace app.startup
{
  public class StartApplication
  {
    public static void run()
    {
      Start.by_running_all_steps_in(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startup_pipeline"));
    }
  }
}