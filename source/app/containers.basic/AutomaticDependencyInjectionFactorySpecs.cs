using System;
using System.Data;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.containers.basic
{
  [Subject(typeof(AutomaticDependencyInjectionFactory))]
  public class AutomaticDependencyInjectionFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneObject,
      AutomaticDependencyInjectionFactory>
    {
    }

    public class when_creating_an_object : concern
    {
      Establish c = () =>
      {
        connection = fake.an<IDbConnection>();
        command = fake.an<IDbCommand>();
        type_to_create = typeof(MyTypeWithDependencies);
        other = new SomeOtherItem(); 
        depends.on(type_to_create);                                         
      };

      Because b = () =>
        result = sut.create();

      It returns_the_object_with_all_of_its_dependencies_provided = () =>
      {
        var result = sut.ShouldBeAn<MyTypeWithDependencies>();
        result.connection.ShouldEqual(connection);
        result.command.ShouldEqual(command);
        result.other.ShouldEqual(other);
      };

      static IDbConnection connection;
      static IDbCommand command;
      static SomeOtherItem other;
      static object result;
      static Type type_to_create;
    }

    public class MyTypeWithDependencies
    {
      public IDbConnection connection { get; private set; }
      public IDbCommand command { get; private set; }
      public SomeOtherItem other { get; private set; }

      public MyTypeWithDependencies(IDbConnection connection, IDbCommand command, SomeOtherItem other)
      {
        this.connection = connection;
        this.command = command;
        this.other = other;
      }

      public MyTypeWithDependencies()
      {
      }

      public MyTypeWithDependencies(IDbConnection connection, IDbCommand command)
      {
        this.connection = connection;
        this.command = command;
      }
    }

    public class SomeOtherItem
    {
    }
  }
}