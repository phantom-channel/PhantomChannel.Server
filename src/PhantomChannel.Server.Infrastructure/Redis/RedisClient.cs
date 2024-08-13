using StackExchange.Redis;

namespace PhantomChannel.Server.Infrastructure.Redis;

public class RedisClient
{

    public RedisClient(string? connectionString)
    {
        ArgumentNullException.ThrowIfNull(connectionString);
        try
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);

        }
        catch (Exception)
        {

            throw new Exception("Redis connection failed");
        }
    }
    private readonly ConnectionMultiplexer _connectionMultiplexer;

    public IDatabase GetDatabase()
    {
        return _connectionMultiplexer.GetDatabase();
    }
}
