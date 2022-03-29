using StackExchange.Redis;
using VotingApp.Core;

namespace VotingApp.Infrastructure.Redis;

public class RedisContext
{
    public IDatabase Votes { get; }

    public RedisContext()
    {
        var connection = ConnectionMultiplexer.Connect(Constants.RedisConnectionStrings);
        Votes = connection.GetDatabase(0);
    }
}
