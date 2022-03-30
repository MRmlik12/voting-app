using MediatR;
using VotingApp.Core.Models;
using VotingApp.Core.Models.Response;
using VotingApp.Core.ProjectAggregate.Vote;
using VotingApp.Core.Utils;
using VotingApp.Infrastructure.Redis.Interfaces;

namespace VotingApp.Application.Vote.CreateVoting;

public class CreateVotingRequestHandler : IRequestHandler<CreateVotingModel, CreateVotingResponseModel>
{
    private readonly IVoteRepository _voteRepository;

    public CreateVotingRequestHandler(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }

    public async Task<CreateVotingResponseModel> Handle(CreateVotingModel request, CancellationToken cancellationToken)
    {
        if (request.VotingItems == null) throw new Exception("Voting items is null");
        
        var code = GenerateCodeUtil.Generate();
        var (key, hash) = GenerateKeyUtil.Generate();
        var voteModel = new Core.ProjectAggregate.Vote.Vote
        {
            Title = request.Title,
            KeyHash = hash,
            VotingItems = request.VotingItems.Select(x => new VoteItem
            {
                FirstName = x.Key,
                SecondName = x.Value,
                Users = new List<VoteUser>()
            }).ToList()
        };

        await _voteRepository.UpdateOrCreate(code, voteModel);

        return new CreateVotingResponseModel
        {
            Code = code,
            Key = key
        };
    }
}
