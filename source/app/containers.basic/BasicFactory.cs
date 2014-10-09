namespace app.containers.basic
{
  public class BasicFactory : ICreateOneObject
  {
    ICreate factory;

    public BasicFactory(ICreate factory)
    {
      this.factory = factory;
    }

    public object create()
    {
      return factory();
    }
  }
}