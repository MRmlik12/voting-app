using System.Security.Cryptography;
using System.Text;
using Bogus;

namespace VotingApp.Core.Utils;

public static class KeyUtils
{
    public static (string, string) Generate()
    {
        var key = new string(new Randomizer().Chars(char.MinValue, char.MaxValue, 32));
        using var sha = SHA512.Create();
        var hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(key));

        return (key, GetHexHash(hashBytes));
    }

    public static bool Verify(string plainKey, string hash)
    {
        using var sha = SHA512.Create();
        var hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plainKey));

        return GetHexHash(hashBytes) == hash;
    }

    private static string GetHexHash(byte[] hashBytes)
    {
        return BitConverter.ToString(hashBytes);
    }
}
