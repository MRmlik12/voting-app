using VotingApp.Core.ProjectAggregate.Vote;

namespace VotingApp.Infrastructure.Redis.Infrastructure;

public interface IVoteRepository
{
    Task Create(string code, VoteModel vote);
    Task<VoteModel?> GetVoteModel(string code);
}
