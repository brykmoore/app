namespace app.utility.mapping
{
  public interface IMap<in Input, out Output>
  {
    Output map(Input input); 
  }
}