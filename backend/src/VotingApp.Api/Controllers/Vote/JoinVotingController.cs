using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Core.Models;

namespace VotingApp.Api.Controllers.Vote;

[ApiController]
[Route("/vote/[controller]")]
public class JoinVotingController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public JoinVotingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> JoinVoting([FromBody] JoinVotingModel joinVotingModel)
    {
        var result = await _mediator.Send(joinVotingModel);

        return Ok(result);
    }
}
