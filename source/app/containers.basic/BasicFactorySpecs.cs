 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.containers.basic
{  
  [Subject(typeof(BasicFactory))]  
  public class BasicFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneObject,
      BasicFactory>
    {
        
    }

   
    public class when_creating_an_object : concern
    {
      Establish c = () =>
      {
        the_connection = fake.an<object>();
        depends.on<ICreate>(() => the_connection);
      };

      Because b = () =>
        result = sut.create();

      It returns_the_result_of_invoking_its_factory_delegate = () =>
        result.ShouldEqual(the_connection);

      static object result;
      static object the_connection;
    }
  }
}
