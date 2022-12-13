using geo_pet.Models;
using geo_pet.services.interfaces;

namespace geo_pet.services
{
  public class QRCodeService : IQRCodeService
  {
    private const string _baseUrl = "https://api.qrserver.com/v1/create-qr-code/";
    private const string _encodedUrl = "https%3A%2F%2Flocalhost%3A7253%2Fusers%2F";
    private const string _qrCodeSize = "100x100";

    public QRCodeService()
    {
    }

    public UserDTOqrcode GetQRCode(int userId)
    {
        var image = $"{_baseUrl}?data={_encodedUrl}{userId}&size={_qrCodeSize}";
        UserDTOqrcode result = new UserDTOqrcode {
            UserId = userId,
            Src = image,
        };
      return result;
    }
  }
}
