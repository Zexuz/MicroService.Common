using QRCoder;

namespace MicroService.Common.Core.Misc
{
    public class QrCodeGenerator
    {
        public static string StringAsBase64ImageData(string text, int size = 5)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new Base64QRCode(qrCodeData);
            return qrCode.GetGraphic(size);
        }
    }
}