using Microsoft.AspNetCore.SignalR.Client;
using VotingApp.IntegrationTests.Fixtures;
using Xunit;

namespace VotingApp.IntegrationTests.Hubs;

public class VotingResultHubTest
{
    private readonly VoteFixture _voteFixture;
    
    public VotingResultHubTest(VoteFixture voteFixture)
    {
        _voteFixture = voteFixture;
    }

    [Fact]
    public async void GetInformationDuringVoting_ChecksResponses()
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost/voteResult")
            .Build();
    }
}
