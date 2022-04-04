using MediatR;
using VotingApp.Core.Models;
using VotingApp.Core.ProjectAggregate.Vote.Dtos;
using VotingApp.Infrastructure.Redis.Interfaces;

namespace VotingApp.Application.Vote.VoteItem;

public class VoteItemRequestHandler : IRequestHandler<VoteItemModel, VotingItemDto>
{
    private readonly IVoteRepository _voteRepository;

    public VoteItemRequestHandler(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }

    public async Task<VotingItemDto> Handle(VoteItemModel request, CancellationToken cancellationToken)
    {
        if (request.Code == null)
            throw new Exception("Code is null");

        var vote = await _voteRepository.GetVoteModel(request.Code);
        var votingItem = new VotingItemDto
        {
            FirstItem = vote?.VotingItems?[request.ItemIndex].FirstName,
            SecondItem = vote?.VotingItems?[request.ItemIndex].SecondName,
            ItemsCount = vote?.VotingItems?.Count
        };

        return votingItem;
    }
}
