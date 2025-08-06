namespace MerkleTree;

public static class Hasher
{
    private static byte[] ComputeHash(string input)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] data = Encoding.UTF8.GetBytes(input);
        byte[] hash = sha256.ComputeHash(data);
        return hash;
    }

    public static string ComputeHashHex(string input)
    {
        byte[] hashBytes = ComputeHash(input);
        StringBuilder sb = new StringBuilder(64);
        foreach (byte b in hashBytes)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
}