using Bogus;

namespace VotingApp.Core.Utils;

public static class GenerateCodeUtil
{
    public static string Generate()
        => new Randomizer().Chars().ToString()!;
}
