using Newtonsoft.Json;
using StackExchange.Redis;
using VotingApp.Core.ProjectAggregate.Vote;

namespace VotingApp.Infrastructure.Redis.Infrastructure.Repositories;

public class VoteRepository : IVoteRepository
{
    private IDatabase Votes { get; }

    public VoteRepository(RedisContext context)
    {
        Votes = context.Votes;
    }

    public async Task Create(string code, VoteModel vote)
    {
        await Votes.StringSetAsync(code, JsonConvert.SerializeObject(vote));
    }
}
