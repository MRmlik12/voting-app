using MediatR;

namespace VotingApp.Core.Models;

public class CreateVotingModel : IRequest<string>
{
    public string? Title { get; set; }
    public Dictionary<string, string>? VotingItems { get; set; }
}
