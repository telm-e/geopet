namespace geo_pet.services.interfaces
{
  public interface IAddressService
  {
    public Task<object> GetAddress(double lat, double lon);
  }
}