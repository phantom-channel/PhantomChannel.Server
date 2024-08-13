using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using PhantomChannel.Server.Application.Interfaces;
using StackExchange.Redis;

namespace PhantomChannel.Server.Application.Services;
public class MailerService : IMailerService
{
    private readonly string _UserName;
    private readonly SmtpClient _client;
    // private readonly IConnectionMultiplexer _redis;
    // 获取 配置文件
    public MailerService(IConfiguration configuration)
    {


        var settings = configuration.GetConnectionString("EmailConnection")!.Split(',')
                               .Select(part => part.Split('='))
                               .ToDictionary(split => split[0].Trim(), split => split[1].Trim());

        var Host = settings["Host"];
        var Port = int.Parse(settings["Port"]);
        var UserName = settings["UserName"];
        var Password = settings["Password"];




        //获取redis 
        // _redis = redis;
        _UserName = UserName;
        _client = new SmtpClient(settings["Host"], Port)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_UserName, Password),
            EnableSsl = true,
        };
    }

    public void SendMail(string to, string subject, string body)
    {
        string _from = $"Fred Foo 👻 < {_UserName} >";
        MailMessage message = new MailMessage(_from, to, subject, body);
        _client.Send(message);
        // _client.SendMailAsync(message);
    }

    public async Task VerifyRegisterEmail(string to)
    {
        Random random = new();
        string verificationCode = random.Next(100000, 999999).ToString();
        // string _from = $"snoozemo.com<{_user}>";
        string _setResdisKey = "VERIFY_REGISTER_CODE_FOR_" + to;

        MailMessage message = new()
        {
            From = new MailAddress(_UserName),
            Subject = "SnoozeMo注册验证码",
            Body = $"<h1>您的验证码为：{verificationCode}，有效期为30分钟，请勿泄露给他人使用。</h1>",
            IsBodyHtml = true,
        };
        // IDatabase db = _redis.GetDatabase();

        try
        {
            // await db.StringSetAsync(_setResdisKey, verificationCode, TimeSpan.FromMinutes(30));

        }
        catch (Exception)
        {
            throw new Exception("验证码发送失败，请稍后再试");
        }


    }
}