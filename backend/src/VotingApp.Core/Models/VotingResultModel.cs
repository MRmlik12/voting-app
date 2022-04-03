using MediatR;
using VotingApp.Core.Models.Response;

namespace VotingApp.Core.Models;

public class VotingResultModel : IRequest<VotingResultResponseModel>
{
    public string? Key { get; set; }
    public string? Code { get; set; }
}
