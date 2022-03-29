using MediatR;
using VotingApp.Core.Models;
using VotingApp.Core.ProjectAggregate.Vote;
using VotingApp.Core.Utils;
using VotingApp.Infrastructure.Redis.Interfaces;

namespace VotingApp.Application.Vote.CreateVoting;

public class CreateVotingRequestHandler : IRequestHandler<CreateVotingModel, string>
{
    private readonly IVoteRepository _voteRepository;

    public CreateVotingRequestHandler(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }

    public async Task<string> Handle(CreateVotingModel request, CancellationToken cancellationToken)
    {
        var code = GenerateCodeUtil.Generate();
        var voteModel = new Core.ProjectAggregate.Vote.Vote
        {
            Title = request.Title,
            VotingItems = new List<VoteItem>()
        };

        await _voteRepository.UpdateOrCreate(code, voteModel);

        return code;
    }
}
