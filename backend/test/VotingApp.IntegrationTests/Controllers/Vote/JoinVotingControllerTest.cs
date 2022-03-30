using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using VotingApp.Core.Models;
using VotingApp.Core.Models.Response;
using VotingApp.IntegrationTests.Fixtures;
using Xunit;

namespace VotingApp.IntegrationTests.Controllers.Vote;

[Collection("Voting collection")]
public class JoinVotingControllerTest
{
    private readonly VoteFixture _voteFixture;
    
    public JoinVotingControllerTest(VoteFixture voteFixture)
    {
        _voteFixture = voteFixture;
    }
    
    [Fact]
    public async void CreateVoting_200_OK_TryParseGuid()
    {
        var body = new JoinVotingModel
        {
            Code = _voteFixture.Code
        };
        
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/vote/JoinVoting", httpContent);
        
        var voterId = JsonConvert.DeserializeObject<JoinVotingResponseModel>(await response.Content.ReadAsStringAsync())!.VoterId;
        _voteFixture.VoterId = voterId;
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
