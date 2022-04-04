using MediatR;

namespace VotingApp.Core.Models;

public class VoteItemModel : IRequest<VotingItem>
{
    public string? Code { get; set; }
    public int ItemIndex { get; set; }
}
