using geo_pet.services.interfaces;

namespace geo_pet.services
{
  public class CepService : ICepService
  {
    private readonly HttpClient _client;
    private const string _baseUrl = "https://viacep.com.br/ws/";

    public CepService(HttpClient client)
    {
      _client = client;
      _client.BaseAddress = new Uri(_baseUrl);
    }

    public async Task<object> GetCep(string cep)
    {
      var response = await _client.GetAsync($"{cep}/json/");
      if (!response.IsSuccessStatusCode)
      {
        return default(Object);
      }

      var result = await response.Content.ReadFromJsonAsync<object>();
      return result;
    }
  }
}
