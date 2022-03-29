using MediatR;
using VotingApp.Core.Models.Response;

namespace VotingApp.Core.Models;

public class JoinVotingModel : IRequest<JoinVotingResponseModel>
{
    public string? Code { get; set; }
}
