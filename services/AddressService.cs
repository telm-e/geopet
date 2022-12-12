using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using geo_pet.services.interfaces;

namespace geo_pet.services
{
  public class AddressService : IAddressService
  {
    private readonly HttpClient _client;
    private const string _baseUrl = "https://nominatim.openstreetmap.org/";

    public AddressService(HttpClient client)
    {
      _client = client;
      _client.BaseAddress = new Uri(_baseUrl);
      _client.DefaultRequestHeaders.Add("User-Agent","Mozilla/5.0 (compatible; AcmeInc/2.0)");
    }
    public async Task<object> GetAddress(double lat, double lon)
    {
      var latitude = lat.ToString().Replace(',','.');
      var longitude = lon.ToString().Replace(',','.');
      var response = await _client.GetAsync($"reverse?lat={latitude}&lon={longitude}&addressdetails=1&format=jsonv2");
      if (!response.IsSuccessStatusCode)
      {
        return default(Object);
      }
      var result = await response.Content.ReadFromJsonAsync<object>();
      return result;
    }
  }
}