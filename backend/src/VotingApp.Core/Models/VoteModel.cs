using MediatR;

namespace VotingApp.Core.Models;

public class VoteModel : IRequest
{
    public string? Code { get; set; }
    public Guid VoterId { get; set; }
    public int ItemIndex { get; set; }
    public int SelectedVote { get; set; }
}
