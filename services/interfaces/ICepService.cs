namespace geo_pet.services.interfaces
{
  public interface ICepService
  {
    public Task<object> GetCep(string cep);
  }
}
