namespace PhantomChannel.Server.Application.Interfaces;

public interface IRSAService
{
    string GetPublicKey();

    string GetPrivateKey();

    string Encrypt(string data);

    string Decrypt(string data);
}
