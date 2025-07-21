
### How to make the app a global command line app
```bash
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish
```

### How ```git add .``` works

| Step                    | Description                                                                         |
| ----------------------- | ----------------------------------------------------------------------------------- |
| 1. **Hash the file**    | Compute a **SHA-1 hash** of the file contents (content-addressing).                 |
| 2. **Create a blob**    | Store the file’s contents as a **blob object** in `.git/objects/`.                  |
| 3. **Update the index** | Add or update the entry for `file.txt` in `.git/index` with its path and blob hash. |

---
Project Structure Idea
```
/Snap
│
├── Program.cs                   # Entry point
├── Snap.csproj
│
├── Commands/                   # CLI commands
│   ├── InitCommand.cs
│   └── AddCommand.cs
│
├── Core/                       # Domain logic (blobs, index, commits)
│   ├── Blob.cs
│   ├── IndexEntry.cs
│   ├── ObjectType.cs           # (optional enum blobs/trees)
│
├── Infrastructure/            # File system, hashing, repo management
│   ├── SnapRepository.cs
│   ├── IHasher.cs
│   ├── Sha1Hasher.cs
│
├── Utils/                     # Helpers/utilities (string, logging, etc.)
│   └── FileHelper.cs          # (optional)
│
└── .snap/                     # Auto-created at runtime
    ├── objects/
    ├── index
    └── HEAD

```