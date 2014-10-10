using System;
using app.reflection;
using app.startup;
using app.utility.mapping;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.stubs
{
  public class StubStartupStep : IRunAStartupStep
  {
    IProvideStartupFeatures startup;

    public StubStartupStep(IProvideStartupFeatures startup)
    {
      this.startup = startup;
    }

    public void run()
    {
    }
  }

  [Subject(typeof(TypeNameToTypeClass))]
  public class TypeNameToTypeClassSpecs
  {
    public abstract class concern : Observes<IMap<string, Type>, TypeNameToTypeClass>
    {
    }

    public class when_mapping_a_named_step_to_its_step_type : concern
    {
      public class and_it_can_be_mapped
      {
        Establish c = () =>
        {
          depends.on(typeof(IRunAStartupStep));
        };

        Because b = () =>
          result = sut.map("app.stubs.StubStartupStep");

        It returns_the_type_object_for_the_step_class = () =>
          result.ShouldEqual(typeof(StubStartupStep));

        static Type result;
      }
    }
  }
}