using VotingApp.Core.Utils;
using Xunit;

namespace VotingApp.UnitTests.Core.Utils;

public class KeyUtilsTest
{
    [Fact]
    public void TestKeyGeneration_VerifyGeneratedKey()
    {
        var (key, hash) = KeyUtils.Generate();
        var result = KeyUtils.Verify(key, hash);
        
        Assert.True(result);
    }
}
