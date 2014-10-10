 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.utility
{  
  [Subject(typeof(RunnableExtensions))]  
  public class RunnableExtensionsSpecs
  {
    public abstract class concern : Observes
    {
        
    }

   
    public class when_combining_commands : concern
    {
      Establish c = () =>
      {
        first = fake.an<IRunnable>();   
        second = fake.an<IRunnable>();   
      };

      Because b = () =>
        result = first.combine_with(second);

      It returns_a_combined_runnable = () =>
      {
        var combined = result.ShouldBeAn<CombinedCommand>();
        combined.first.ShouldEqual(first);
        combined.second.ShouldEqual(second);
      };

      static IRunnable result;
      static IRunnable second;
      static IRunnable first;
    }
  }
}
