using snap.Core;
using snap.Infra;
using Snap.Infrastructure;



public class AddCommand
{
    public static void Run(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: snap add <filename>");
            return;
        }

        string filePath = args[1];
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return;
        }

        var content = File.ReadAllText(filePath);
        IHasher hasher = new Sha256Hasher();
        var blob = new Blob(content, hasher);

        var repo = new SnapRepository();
        repo.SaveBlob(blob);
        repo.UpdateIndex(new IndexEntry { FilePath = filePath, Hash = blob.Hash });

        Console.WriteLine($"Added {filePath} with hash {blob.Hash}");
    }
}

