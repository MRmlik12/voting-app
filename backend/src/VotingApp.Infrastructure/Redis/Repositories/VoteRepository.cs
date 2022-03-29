using Newtonsoft.Json;
using StackExchange.Redis;
using VotingApp.Core.ProjectAggregate.Vote;
using VotingApp.Infrastructure.Redis.Infrastructure;

namespace VotingApp.Infrastructure.Redis.Repositories;

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

    public async Task<VoteModel?> GetVoteModel(string code)
    {
        try
        {
            var voting = await Votes.StringGetAsync(code);

            return voting.ToString() == null
                ? null
                : JsonConvert.DeserializeObject<VoteModel>(voting.ToString());
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
