using MediatR;
using VotingApp.Core.Models;
using VotingApp.Core.ProjectAggregate.Vote;
using VotingApp.Infrastructure.Redis.Interfaces;

namespace VotingApp.Application.Vote.CastVote;

public class CastVoteRequestHandler : IRequestHandler<VoteModel>
{
    private readonly IVoteRepository _voteRepository;

    public CastVoteRequestHandler(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }

    public async Task<Unit> Handle(VoteModel request, CancellationToken cancellationToken)
    {
        var vote = await _voteRepository.GetVoteModel(request.Code!);
        if (vote == null)
            throw new Exception("Vote is null");

        var user = new VoteUser
        {
            Id = request.VoterId,
            Vote = request.SelectedVote
        };

        vote.VotingItems?[request.ItemIndex].Users?.Add(user);
        await _voteRepository.UpdateOrCreate(request.Code!, vote);

        return Unit.Value;
    }
}
