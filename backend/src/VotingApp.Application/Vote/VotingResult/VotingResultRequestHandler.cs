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
        var voting = await _voteRepository.GetVoteModel(request.Code!);

        if (voting == null)
            throw new Exception("Invalid code");

        if (!KeyUtils.Verify(request.Key!, voting.KeyHash!))
            throw new Exception("Access denied");

        var voteResult = new VotingResultResponseModel
        {
            Code = request.Code,
            ParticipantsCount = voting.Participants?.Count,
            Votes = new List<VoteModels>()
        };

        voteResult.Votes = voting.VotingItems?.Select(x => new VoteModels
        {
            FirstVote = new VoteDetail
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
