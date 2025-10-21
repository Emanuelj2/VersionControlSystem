namespace VersionControlSystem.Models
{
    internal class IndexEntry
    {
        public string? Path { get; set; }
        public string? Hash { get; set; }
    }
}

/*
Think of the index as a list of all files you’ve marked for commit.
Each file has:

Path → the location of the file in your project (e.g. "src/main.cs").

Hash → a unique identifier (often a SHA-1 or SHA-256 hash) representing the content of that file at the moment it was staged.

So if you run a “vcs add file.txt” command in your version control system, it would:

Compute the hash of file.txt’s contents.

Store a new IndexEntry with that Path and Hash.

This allows your system to know exactly which version of each file was staged for commit.
*/