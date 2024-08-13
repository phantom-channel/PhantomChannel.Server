using System.Security.Cryptography;
using System.Text;
using PhantomChannel.Server.Application.Interfaces;

namespace PhantomChannel.Server.Application.Services;
public sealed class RSAService : IRSAService
{

    private readonly RSA _rsa;

    public RSAService()
    {
        _rsa = RSA.Create();
    }


    public string GetPublicKey()
    {
        return _rsa.ExportRSAPublicKeyPem();
    }

    public string GetPrivateKey()
    {
        return _rsa.ExportRSAPrivateKeyPem();
    }


    public string Encrypt(string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        var encryptedBytes = _rsa.Encrypt(bytes, RSAEncryptionPadding.Pkcs1);
        return Convert.ToBase64String(encryptedBytes);
    }


    public string Decrypt(string data)
    {
        var bytes = Convert.FromBase64String(data);
        var decryptedBytes = _rsa.Decrypt(bytes, RSAEncryptionPadding.Pkcs1);
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}