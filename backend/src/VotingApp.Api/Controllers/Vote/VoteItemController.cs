using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Core.Models;

namespace VotingApp.Api.Controllers.Vote;

[ApiController]
[Route("/vote/[controller]")]
public class VoteItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public VoteItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetVoteItem([FromQuery] string code, [FromQuery] int itemIndex = 0)
    {
        var getVoteItemModel = new VoteItemModel
        {
            Code = code,
            ItemIndex = itemIndex
        };

        var result = await _mediator.Send(getVoteItemModel);

        return Ok(result);
    }
}
