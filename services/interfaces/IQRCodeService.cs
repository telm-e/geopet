using geo_pet.Models;

namespace geo_pet.services.interfaces
{
  public interface IQRCodeService
  {
    public UserDTOqrcode GetQRCode(int userId);
  }
}
