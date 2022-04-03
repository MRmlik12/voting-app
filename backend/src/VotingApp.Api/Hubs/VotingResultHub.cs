using MediatR;
using Microsoft.AspNetCore.SignalR;
using VotingApp.Core.Models;

namespace VotingApp.Api.Hubs;

public class VotingResultHub : Hub
{
    private readonly IMediator _mediator;

    public VotingResultHub(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task SendMessage(VotingResultModel votingResultModel)
    {
        var result = await _mediator.Send(votingResultModel);
        
        await Clients.All.SendAsync("ReceiveMessage", result);
    }
}
