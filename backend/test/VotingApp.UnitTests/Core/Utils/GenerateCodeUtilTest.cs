using VotingApp.Core.Utils;
using Xunit;

namespace VotingApp.UnitTests.Core.Utils;

public class GenerateCodeUtilTest
{
    private const int CodeLenght = 10;

    [Fact]
    public void GetGeneratedCode_ChecksLenght_10_AndTypeString()
    {
        var generatedCode = GenerateCodeUtil.Generate();

        Assert.Equal(CodeLenght, generatedCode.Length);
        Assert.IsType<string>(generatedCode);
    }
}
