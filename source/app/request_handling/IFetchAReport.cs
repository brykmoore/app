namespace app.request_handling
{
  public delegate Report IFetchAReport<out Report>(IProvideRequestDetails request);

  public interface IFetchA<out Report>
  {
    Report fetch_using(IProvideRequestDetails request); 
  }
}