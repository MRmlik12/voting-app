using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Core.Models;

namespace VotingApp.Api.Controllers.Vote;

[ApiController]
[Route("/vote/[controller]")]
public class CreateVotingController : ControllerBase
{
    private readonly IMediator _mediator;

    public CreateVotingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateVoting([FromBody] CreateVotingModel model)
    {
        var result = await _mediator.Send(model);

        return Ok(result);
    }
}
