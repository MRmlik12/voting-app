using Bogus;

namespace VotingApp.Core.Utils;

public static class GenerateCodeUtil
{
    public static string Generate()
        => new(new Randomizer().Chars('a', 'z', 10));
}
