using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using VotingApp.Core.Models;
using VotingApp.IntegrationTests.Fixtures;
using Xunit;

namespace VotingApp.IntegrationTests.Controllers.Vote;

[Collection("Voting collection")]
public class VoteCastControllerTest
{
    private readonly VoteFixture _voteFixture;

    public VoteCastControllerTest(VoteFixture voteFixture)
    {
        _voteFixture = voteFixture;
    }

    [Fact]
    public async void CastVote_200_OK()
    {
        var body = new VoteModel
        {
            Code = _voteFixture.Code,
            VoterId = _voteFixture.VoterId,
            ItemIndex = 1,
            SelectedVote = 0
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/vote/CastVote", httpContent);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
