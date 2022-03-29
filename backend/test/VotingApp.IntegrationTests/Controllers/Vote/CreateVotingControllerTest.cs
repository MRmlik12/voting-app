using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using VotingApp.Core.Models;
using VotingApp.IntegrationTests.Fixtures;
using Xunit;

namespace VotingApp.IntegrationTests.Controllers.Vote;

public class CreateVotingControllerTest
{
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
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
