using QRCoder;
using Startup.Business.Services.Interfaces;

namespace Startup.Business.Services;

public class AuthenticatorService : IAuthenticatorService
{
    public byte[] GenerateCode(string authenticatorUri)
    {
        //otpauth://totp/ACME%20Co:john.doe@email.com?secret=HXDMVJECJJWSRB3HWIZR4IFUGFTMXBOZ&issuer=ACME%20Co&algorithm=SHA1&digits=6&period=30

        using QRCodeGenerator qrGenerator = new QRCodeGenerator();
        using QRCodeData qrCodeData = qrGenerator.CreateQrCode(authenticatorUri, QRCodeGenerator.ECCLevel.Q);
        using PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
        
        byte[] qrCodeImage = qrCode.GetGraphic(20);

        return qrCodeImage;
    }
}