namespace app.utility
{
  public static class RunnableExtensions
  {
    public static IRunnable combine_with(this IRunnable first, IRunnable second)
    {
      return new CombinedCommand(first, second);
    } 
  }
}