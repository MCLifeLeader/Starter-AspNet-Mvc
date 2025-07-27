namespace Startup.Business.Services.Interfaces;

public interface IAuthenticatorService
{
    public byte[] GenerateCode(string authenticatorUri);
}