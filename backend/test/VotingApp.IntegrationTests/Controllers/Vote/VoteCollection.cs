using VotingApp.IntegrationTests.Fixtures;
using Xunit;

namespace VotingApp.IntegrationTests.Controllers.Vote;

[CollectionDefinition("Voting collection")]
public class VoteCollection : ICollectionFixture<VoteFixture>
{
}
