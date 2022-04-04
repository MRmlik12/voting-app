using System.Net;
using FluentAssertions;
using VotingApp.Core.Models;
using VotingApp.IntegrationTests.Fixtures;
using Xunit;
using Newtonsoft.Json;

namespace VotingApp.IntegrationTests.Controllers.Vote;

[Collection("Voting collection")]
public class VoteItemControllerTest
{
    private readonly VoteFixture _voteFixture;

    public VoteItemControllerTest(VoteFixture voteFixture)
    {
        _voteFixture = voteFixture;
    }

    [Fact]
    public async void VoteItem_200_OK()
    {
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        using var response = await client.GetAsync($"/vote/VoteItem?code={_voteFixture.Code}&itemIndex=0");
        var responseBody = JsonConvert.DeserializeObject<VotingItem>(await response.Content.ReadAsStringAsync());

        responseBody.Should().NotBeNull();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
