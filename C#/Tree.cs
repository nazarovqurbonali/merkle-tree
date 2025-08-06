namespace MerkleTree;

public class Tree
{
   public static List<string> Hashes = [];

    string[] _transactions;

    public Tree(string[] tx)
    {
        _transactions = tx;

        if (!IsPowerOfTwo(_transactions.Length))
            throw new Exception("Invalid number of transactions");

        foreach (string transaction in _transactions)
        {
            Hashes.Add(Hasher.ComputeHashHex(transaction));
        }

        int txLength = _transactions.Length;
        int offset = 0;

        while (txLength > 0)
        {
            for (int i = 0; i < txLength - 1; i += 2)
            {
                Hashes.Add(Hasher.ComputeHashHex(
                    Hashes[offset + i] + Hashes[offset + i + 1]));
            }

            offset += txLength;
            txLength /= 2;
        }
    }

    public bool Verify(string transaction, int index, string rootHash, List<string> proof)
    {
        string trHash = Hasher.ComputeHashHex(transaction);
        for (int i = 0; i < proof.Count; i++)
        {
            string element = proof[i];
            if (index % 2 == 0)
            {
                trHash = Hasher.ComputeHashHex(trHash + element);
            }
            else
            {
                trHash = Hasher.ComputeHashHex(element + trHash);
            }

            index /= 2;
        }

        return trHash == rootHash;
    }

    bool IsPowerOfTwo(int length)
    {
        return length > 0 && (length & (length - 1)) == 0;
    }
}