using System;

namespace VotingApp.IntegrationTests.Fixtures;

public class VoteFixture
{
    public string Code { get; set; } = null!;
    public Guid VoterId { get; set; }
}
