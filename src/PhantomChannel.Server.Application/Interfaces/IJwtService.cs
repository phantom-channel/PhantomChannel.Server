namespace PhantomChannel.Server.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string userId, string userRole);
    }
}