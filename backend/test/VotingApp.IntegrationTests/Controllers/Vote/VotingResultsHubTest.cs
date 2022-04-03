using FluentAssertions;
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
        var port = application.Server.BaseAddress.Port;

        var result = new VotingResultResponseModel();
        var connection = new HubConnectionBuilder()
            .WithUrl($"ws://localhost:{port}/VotingResult")
            .Build();
        
        connection.On<VotingResultResponseModel>("OnReceiveMessage", msg =>
        {
            result = msg;
        });
        
        await connection.StartAsync();
        await connection.InvokeAsync("Send", message);

        result.Should().NotBeNull();
    }
}
