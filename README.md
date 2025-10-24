# SimpleVCS - A Simple Version Control System

A lightweight, educational implementation of a version control system inspired by Git, built in C#. SimpleVCS demonstrates the core concepts of version control including content-addressed storage, staging, commits, and history tracking.

##  Features

- **Initialize Repository** - Create a new version control repository
- **Stage Files** - Add files to the staging area
- **Commit Changes** - Create snapshots of your project with messages
- **View History** - Browse through commit history
- **Check Status** - See what files are staged
- **Binary File Support** - Works with images, documents, and any file type
- **Content-Addressed Storage** - Efficient storage using SHA-1 hashing

##  Requirements

- .NET 6.0 or higher
- Windows, macOS, or Linux

##  Installation

### Option 1: Build from Source

```bash
# Clone or download the project
cd SimpleVCS

# Build the project
dotnet build

# Run from source
dotnet run -- <command>
```

### Basic Commands

```bash
# Initialize a new repository
simplevcs init

# Add a file to staging area
simplevcs add <filename>

# Create a commit
simplevcs commit "Your commit message"

# View commit history
simplevcs log

# Check repository status
simplevcs status
```

##  Examples

### Example 1: Text Files

```bash
# Create a new project
mkdir MyProject
cd MyProject

# Initialize repository
simplevcs init
# Output: Initialized empty SimpleVCS repository.

# Create and add a file
echo "Hello World" > README.txt
simplevcs add README.txt
# Output: Added 'README.txt' to staging area.

# Commit the change
simplevcs commit "Initial commit"
# Output: [a3f5b21] Initial commit

# Make changes
echo "More content" >> README.txt
simplevcs add README.txt
simplevcs commit "Added more content"

# View history
simplevcs log
```

##  Project Structure

```
SimpleVCS/
├── Models/                    # Data models
│   ├── Commit.cs             # Commit structure
│   └── IndexEntry.cs         # Staging area entry
├── Core/                      # Core utilities
│   ├── Constants.cs          # Configuration constants
│   └── HashUtility.cs        # SHA-1 hashing
├── Storage/                   # Storage layer
│   ├── ObjectStore.cs        # Object storage/retrieval
│   ├── IndexManager.cs       # Staging area management
│   └── ReferenceManager.cs   # Branch and HEAD management
├── Repository/                # Repository operations
│   ├── TreeBuilder.cs        # Tree object creation
│   └── CommitManager.cs      # Commit operations
├── Commands/                  # Command implementations
│   ├── InitCommand.cs        # init command
│   ├── AddCommand.cs         # add command
│   ├── CommitCommand.cs      # commit command
│   ├── LogCommand.cs         # log command
│   └── StatusCommand.cs      # status command
└── Program.cs                 # CLI entry point
```


##  How It Works

### Content-Addressed Storage
Files are stored using SHA-1 hashing. Identical files share the same storage, preventing duplication.

### Three Object Types
1. **Blob** - Raw file content
2. **Tree** - Directory structure and file list
3. **Commit** - Snapshot with metadata (author, message, timestamp, parent)

### Staging Area (Index)
Files must be added to the staging area before committing. This allows you to control exactly what goes into each commit.

### Commit History
Each commit points to its parent, forming a linked history of changes.

##  Use Cases

- **Learning Version Control** - Understand how Git works under the hood
- **Small Projects** - Track changes in personal projects
- **Design Assets** - Version control for images and design files
- **Documentation** - Track document revisions
- **Code Snippets** - Manage your code examples


##  Learning Resources

To understand version control concepts better:
- [Git Internals](https://git-scm.com/book/en/v2/Git-Internals-Plumbing-and-Porcelain)
- [Building Git](https://shop.jcoglan.com/building-git/)
- [Write Yourself a Git](https://wyag.thb.lt/)



