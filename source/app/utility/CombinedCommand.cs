namespace app.utility
{
  public class CombinedCommand : IRunnable
  {
    public IRunnable first;
    public IRunnable second;

    public CombinedCommand(IRunnable first, IRunnable second)
    {
      this.first = first;
      this.second = second;
    }

    public void run()
    {
      first.run();
      second.run();
    }
  }

}