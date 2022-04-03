using MediatR;
using VotingApp.Core.Models;
using VotingApp.Core.Models.Response;
using VotingApp.Infrastructure.Redis.Interfaces;

namespace VotingApp.Application.Vote.JoinVoting;

public class JoinVotingRequestHandler : IRequestHandler<JoinVotingModel, JoinVotingResponseModel>
{
    private readonly IVoteRepository _voteRepository;

    public JoinVotingRequestHandler(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }

    public async Task<JoinVotingResponseModel> Handle(JoinVotingModel request, CancellationToken cancellationToken)
    {
        if (request.Code == null)
            throw new Exception("Code property is null");

        var vote = await _voteRepository.GetVoteModel(request.Code);
        if (vote == null)
            throw new Exception("Invalid code");

        var id = Guid.NewGuid();
        vote.Participants?.Add(id);

        var voterResponseModel = new JoinVotingResponseModel
        {
            VoterId = id
        };

        return voterResponseModel;
    }
}
