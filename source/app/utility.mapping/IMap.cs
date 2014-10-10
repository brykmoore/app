namespace app.utility.mapping
{
  public interface IMap<in Input, out Output>
  {
    Output map(Input input); 
  }

  public delegate Output IMapper<in Input, out Output>(Input input);
}