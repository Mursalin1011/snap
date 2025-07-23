using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using snap.Infra;

namespace snap.Core
{
    //A blob object has two properties:
    // 1. Hash: A SHA-256 hash of the content.
    // 2. Content: The actual content or the text.
    public class Blob
    {
        public string Hash { get; }
        public string Content { get; }
        public Blob(string content, IHasher hasher) 
        {
            Content = content;
            Hash = hasher.ComputeHash(content);
        }
        public void Save(string objectsPath)
        {
            string objectPath = Path.Combine(objectsPath, Hash);
            if (!File.Exists(objectPath))
            {
                File.WriteAllText(objectPath, Content);
            }
        }
    }
}
