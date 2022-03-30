using System.Collections.Generic;
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
public class CreateVotingControllerTest
{
    private const int CodeLenght = 10;
    private readonly VoteFixture _voteFixture;

    public CreateVotingControllerTest(VoteFixture voteFixture)
    {
        _voteFixture = voteFixture;
    }

    [Fact]
    public async void CreateVoting_200_OK()
    {
        var body = new CreateVotingModel
        {
            Title = "Example",
            VotingItems = new Dictionary<string, string>
            {
                { "Milk", "Bread" },
                { "Apple", "Banana" },
                { "Cherry", "Mango" }
            }
        };

        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/vote/CreateVoting", httpContent);

        var responseModel =
            JsonConvert.DeserializeObject<CreateVotingResponseModel>(await response.Content.ReadAsStringAsync());
        _voteFixture.Code = responseModel!.Code!;

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(CodeLenght, responseModel.Code!.Length);
    }
}
