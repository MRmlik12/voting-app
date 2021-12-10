namespace VotingApp.Core;

public static class Constants
{
    public static string? RedisConnectionStrings
        => Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRINGS") ?? throw new Exception("REDIS_CONNECTION_STRING env is empty");
}
