namespace app.containers.basic
{
  public interface ICreateOneObject
  {
    object create(); 
  }

  public delegate object ICreate();
}