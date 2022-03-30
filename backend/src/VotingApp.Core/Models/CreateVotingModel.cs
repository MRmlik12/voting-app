using MediatR;
using VotingApp.Core.Models.Response;

namespace VotingApp.Core.Models;

public class CreateVotingModel : IRequest<CreateVotingResponseModel>
{
    public string? Title { get; set; }
    public Dictionary<string, string>? VotingItems { get; set; }
}
