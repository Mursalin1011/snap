
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



## How to make the app a global command line app
```bash
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish
```

## How ```git add .``` works

| Step                    | Description                                                                         |
| ----------------------- | ----------------------------------------------------------------------------------- |
| 1. **Hash the file**    | Compute a **SHA-1 hash** of the file contents (content-addressing).                 |
| 2. **Create a blob**    | Store the file’s contents as a **blob object** in `.git/objects/`.                  |
| 3. **Update the index** | Add or update the entry for `file.txt` in `.git/index` with its path and blob hash. |

---
## Project Structure Idea
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

## Design Patterns


### 1. **Command Pattern** → `AddCommand`, `InitCommand`

>  **Why?** Each command (`snap init`, `snap add`) does something unique.  
>  This pattern helps us keep each command **isolated**, clean, and easily extendable.

Imagine a vending machine — you press a different button for Coke, Water, or Juice. Each button has its own logic. Same here.

### 2. **Repository Pattern** → `SnapRepository`

>  **Why?** We need to read/write blobs, update index, etc.  
>  Instead of writing file I/O code everywhere, we centralize it here.

It’s like having one person (the "Repository") in your bakery who manages all your storage (fridge, pantry, cashbox).

### 3. **Strategy Pattern** → `IHasher`, `Sha1Hasher`

>  **Why?** You might use different hashing (SHA-1 today, SHA-256 tomorrow).  
>  Let’s keep the hashing logic **pluggable** and not hardcoded.

Like having a mixer that you can change blades for — one blade chops, one blends. You choose at runtime.

### 4. **Value Object Pattern** → `Blob`, `IndexEntry`

>  **Why?** These classes represent **data**, not behavior.  
>  They’re immutable. If content changes, it's a new blob.

Think of it like a cake — once baked, you can’t change it. You just bake another if needed.

