using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.utility
{
  [Subject(typeof(CombinedCommand))]
  public class CombinedCommandSpecs
  {
    public abstract class concern : Observes<IRunnable,
      CombinedCommand>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        first = fake.an<IRunnable>();
        second = fake.an<IRunnable>();
        sut_factory.create_using(() => new CombinedCommand(first, second));
      };

      Because b = () =>
        sut.run();

      It runs_the_first_then_second_command = () =>
      {
        first.received(x => x.run());
        second.received(x => x.run());
      };

      static IRunnable first;
      static IRunnable second;
    }
  }
}