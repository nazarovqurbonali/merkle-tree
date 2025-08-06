string[] _transactions =
{
    "TX:A->B",
    "TX:B->C",
    "TX:C->D",
    "TX:D->E",
};

// Create a Merkle tree from the list of transactions
Tree tree = new Tree(_transactions);

// Merkle root is the last hash in the list of all hashes
string rootHash = Tree.Hashes[^1];

// For example, create a proof for the transaction at index 2 ("TX:C->D")
// A proof is a list of sibling hashes that allow verification of a leaf's membership in the tree
// For 4 transactions, the proof will usually have 2 hashes:
// proof[0] = sibling hash at the leaf level
// proof[1] = hash at the next upper level
// Here we use placeholder values (not a correct proof, just for syntax)
var proof = new List<string>
{
    Tree.Hashes[3], // sibling hash of "TX:D->E"
    Tree.Hashes[4], // parent hash at the next level
};

// Verify if the transaction is included in the Merkle tree with the given root and proof
bool isValid = tree.Verify("TX:C->D", 2, rootHash, proof);

Console.WriteLine("Verification result: " + isValid);