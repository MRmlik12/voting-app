using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using VotingApp.Core.Models;
using VotingApp.IntegrationTests.Fixtures;
using Xunit;
using Xunit.Priority;

namespace VotingApp.IntegrationTests.Controllers.Vote;

[Collection("Voting collection")]
[DefaultPriority(0)]
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
            VotingItems = new List<VotingItem>
            {
                new ()
                {
                    FirstItem = "Milk",
                    SecondItem = "Bread"
                },
                new ()
                { 
                    FirstItem ="Apple",
                    SecondItem = "Banana" 
                },
               new ()
               {
                   FirstItem = "Cherry", 
                   SecondItem = "Mango"
               }
            }
        };
        
        await using var application = new WebServerFactory();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/vote/CreateVoting", httpContent);
        
        var code = await response.Content.ReadAsStringAsync();
        _voteFixture.Code = code;
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(CodeLenght, code.Length);
    }
}
