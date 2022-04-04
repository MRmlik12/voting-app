using MediatR;
using VotingApp.Core.ProjectAggregate.Vote.Dtos;

namespace VotingApp.Core.Models;

public class VoteItemModel : IRequest<VotingItemDto>
{
    public string? Code { get; set; }
    public int ItemIndex { get; set; }
}
