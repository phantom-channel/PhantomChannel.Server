using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhantomChannel.Server.Application.Interfaces;

namespace PhantomChannel.Server.Application.Services;
public class JwtService(IConfiguration configuration) : IJwtService
{
    private readonly byte[] key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
    private readonly string Issuer = configuration["Jwt:Issuer"]!;
    private readonly string Audience = configuration["Jwt:Audience"]!;
    private readonly double Expires = double.Parse(configuration["Jwt:ExpireMinutes"]!);

    public string GenerateJwtToken(string userId, string userRole)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, "testuser"),
                new Claim(ClaimTypes.Role, "SuperAdmin")
            ]),
            Expires = DateTime.UtcNow.AddMinutes(Expires),
            SigningCredentials = SigningCredentials,
            Issuer = Issuer,
            Audience = Audience
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
