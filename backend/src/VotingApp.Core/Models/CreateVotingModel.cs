using MediatR;

namespace VotingApp.Core.Models;

public class CreateVotingModel : IRequest<string>
{
    public string? Title { get; set; }
    public List<VotingItem>? VotingItems { get; set; }
}

public class VotingItem
{
    public string? FirstItem { get; set; }
    public string? SecondItem { get; set; }
}

