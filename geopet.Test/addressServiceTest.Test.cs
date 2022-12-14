using System.Text.Json;
using geo_pet.services;
using Moq;

public class addressServiceTest
{
  [Fact]
  public async Task MustReturnAddressByLatitudeAndLongitude()
  {
    var mockClient = new Mock<HttpClient>();
    var addressService = new AddressService(mockClient.Object);
    var response = await addressService.GetAddress(-19.912998, -43.940933);
    response.Should().BeOfType<JsonElement>();
    response.Should().NotBeNull();
  }
}

