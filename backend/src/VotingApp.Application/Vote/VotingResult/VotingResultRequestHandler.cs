using MediatR;
using VotingApp.Core.Models;
using VotingApp.Core.Models.Response;
using VotingApp.Core.Utils;
using VotingApp.Infrastructure.Redis.Interfaces;

namespace VotingApp.Application.Vote.VotingResult;

public class VotingResultRequestHandler : IRequestHandler<VotingResultModel, VotingResultResponseModel>
{
    private readonly IVoteRepository _voteRepository;

    public VotingResultRequestHandler(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }

    public async Task<VotingResultResponseModel> Handle(VotingResultModel request, CancellationToken cancellationToken)
    {
        var votes = await _voteRepository.GetVoteModel(request.Code!);

        if (votes == null)
            throw new Exception("Invalid code");

        if (!KeyUtils.Verify(request.Key!, votes.KeyHash!))
            throw new Exception("Access denied");

        var voteResult = new VotingResultResponseModel
        {
            Code = request.Code,
            ParticipantsCount = votes.Participants?.Count,
            Votes = new List<VoteModels>()
        };

        voteResult.Votes = votes.VotingItems?.Select(x => new VoteModels
        {
            FistVote = new VoteDetail
            {
                Name = x.FirstName!,
                Count = x.Users?.Where(x => x.Vote == 0).Count()
            },
            SecondVote = new VoteDetail
            {
                Name = x.SecondName!,
                Count = x.Users?.Where(x => x.Vote == 1).Count()
            }
        }).ToList();

        return voteResult;
    }
}
