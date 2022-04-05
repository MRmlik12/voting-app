using FluentAssertions;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using VotingApp.Core.Models;
using VotingApp.Core.Models.Response;
using VotingApp.IntegrationTests.Fixtures;
using Xunit;

namespace VotingApp.IntegrationTests.Controllers.Vote;

[Collection("Voting collection")]
public class VotingResultsHubTest
{
    private readonly VoteFixture _voteFixture;
    
    public VotingResultsHubTest(VoteFixture voteFixture)
    {
        _voteFixture = voteFixture;
    }

    [Fact]
    public async void TestVotingResultHub_CheckResponse()
    {
        var message = new VotingResultModel
        {
            Key = _voteFixture.Key,
            Code = _voteFixture.Code
        };
        
        await using var application = new WebServerFactory();

        var result = new VotingResultResponseModel();
        var connection = new HubConnectionBuilder()
            .WithUrl("ws://localhost:80/hub/votingResults", o =>
            {
                o.HttpMessageHandlerFactory = _ => application.Server.CreateHandler();
            })
            .Build();
        
        connection.On<VotingResultResponseModel>("OnReceiveMessage", msg =>
        {
            result = msg;
        });
        
        await connection.StartAsync();
        await connection.InvokeAsync("SendMessage", message);

        result.Should().NotBeNull();
    }
}
