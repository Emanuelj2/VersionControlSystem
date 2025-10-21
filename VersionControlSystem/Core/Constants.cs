namespace VersionControlSystem.Core
{
    internal class Constants
    {
        public const string VCS_DIR = ".vcs";
        public const string OBJECTS_DIR = ".vcs/objects";
        public const string REFS_DIR = ".vcs/refs";
        public const string HEADS_DIR = ".vcs/refs/heads";
        public const string INDEX_FILE = ".vcs/index";
        public const string HEAD_FILE = ".vcs/HEAD";
        public const string DEFAULT_BRANCH = "master";
    }
}

/*
| **Constant**     | **Represents**                      | **Example Path / Value** | **What It Does**                                                                                                                               |
| ---------------- | ----------------------------------- | ------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| `VCS_DIR`        | Root version control folder         | `.vcs/`                  | The main hidden directory that stores all version control data (objects, commits, branches, etc.). Created when the repository is initialized. |
| `OBJECTS_DIR`    | Storage for file and commit objects | `.vcs/objects/`          | Holds all versioned data — files (blobs), directory trees, and commits — usually stored by their hash for content integrity and deduplication. |
| `REFS_DIR`       | Directory for references            | `.vcs/refs/`             | Keeps pointers (references) to commits, branches, and tags. Used to track which commit each branch or tag currently points to.                 |
| `HEADS_DIR`      | Directory for branch references     | `.vcs/refs/heads/`       | Contains a file for each branch, where each file stores the hash of the branch’s latest commit.                                                |
| `INDEX_FILE`     | The index (staging area) file       | `.vcs/index`             | Stores a list of staged files (`IndexEntry` objects) and their hashes — used to prepare changes before committing.                             |
| `HEAD_FILE`      | The HEAD pointer                    | `.vcs/HEAD`              | Points to the current branch or commit. Determines what is currently “checked out” in the working directory.                                   |
| `DEFAULT_BRANCH` | Default branch name                 | `master`                 | Defines the default branch created when the repository is initialized (used for the first commit).                                             |
*/