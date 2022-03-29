using VotingApp.Core.ProjectAggregate.Vote;

namespace VotingApp.Infrastructure.Redis.Interfaces;

public interface IVoteRepository
{
    Task UpdateOrCreate(string code, Vote vote);
    Task<Vote?> GetVoteModel(string code);
}
