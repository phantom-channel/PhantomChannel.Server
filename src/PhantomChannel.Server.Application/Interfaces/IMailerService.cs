
namespace PhantomChannel.Server.Application.Interfaces;

public interface IMailerService
{
    void SendMail(string to, string subject, string body);

}