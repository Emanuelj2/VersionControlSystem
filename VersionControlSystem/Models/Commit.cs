namespace VersionControlSystem.Models
{
    internal class Commit
    {
        public string? Hash { get; set; }
        public string? TreeHash { get; set; }
        public string? ParentHash { get; set; }
        public string? Message { get; set; }
        public string? Author { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

/*
 Hash → the unique identifier for the commit itself (e.g. a hash of all its metadata and tree).

TreeHash → refers to a tree object (or root of your file structure) — essentially, the hash that represents the entire project state (the collection of all files and directories).

ParentHash → the commit that came before this one. This links commits together into a chain (or graph) — your commit history.

Message → the commit message (e.g. "Fixed bug in login system").

Author → the person who made the commit (e.g. "Emanuel Jose").

Timestamp → when the commit was created.
*/