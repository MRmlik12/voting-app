using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Core.Models;

namespace VotingApp.Api.Controllers.Vote;

[ApiController]
[Route("/vote/[controller]")]
public class CastVoteController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CastVoteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Vote([FromBody] VoteModel vote)
    {
        await _mediator.Send(vote);

        return Ok();
    }
}
