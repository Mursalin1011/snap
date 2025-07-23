using System.Text.Json;
using snap.Core;

namespace Snap.Infrastructure
{
    public class SnapRepository
    {
        private readonly string snapDir = Path.Combine(Directory.GetCurrentDirectory(), ".snap");
        private readonly string objectsPath;
        private readonly string indexPath;

        public SnapRepository()
        {
            objectsPath = Path.Combine(snapDir, "objects");
            indexPath = Path.Combine(snapDir, "index");
        }

        public void SaveBlob(Blob blob)
        {
            blob.Save(objectsPath);
        }

        public void UpdateIndex(IndexEntry entry)
        {
            var entries = new List<IndexEntry>();

            if (File.Exists(indexPath))
            {
                var json = File.ReadAllText(indexPath);
                entries = JsonSerializer.Deserialize<List<IndexEntry>>(json) ?? new List<IndexEntry>();
            }

            entries.RemoveAll(e => e.FilePath == entry.FilePath);
            entries.Add(entry);

            var newJson = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(indexPath, newJson);
        }
    }
}
