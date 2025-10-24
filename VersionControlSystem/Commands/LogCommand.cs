using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionControlSystem.Repository;
using VersionControlSystem.Storage;

namespace VersionControlSystem.Commands
{
    internal class LogCommand
    {
        public static void Execute()
        {
            //check if you are in a VCS repository
            if (!Directory.Exists(Core.Constants.VCS_DIR))
            {
                Console.WriteLine("Not a VCS repository. Please initialize first.");
                return;
            }

            var commitHashes = ReferenceManager.GetCurrentCommitHash();

            //check if there are any commits
            if (string.IsNullOrEmpty(commitHashes))
            {
                Console.WriteLine("No commits found.");
                return;
            }

            //traverse the commit history backwards
            while (!string.IsNullOrEmpty(commitHashes))
            {
                var commit = CommitManager.LoadCommit(commitHashes);
                if(commit == null)
                {
                    break;
                }
                Console.WriteLine($"Commit: {commit.Hash}");
                Console.WriteLine($"Author: {commit.Author}");
                Console.WriteLine($"Date: {commit.Timestamp.ToLocalTime()}");
                Console.WriteLine($"\n    {commit.Message}\n");

                commitHashes = commit.ParentHash!;
            }

        }
    }
}
//LogCommand displays a chronological list of
//commits — showing their hash, author, date,
//and message — by traversing the commit history backward (from the most recent commit to the first).

/*
| Step | Action              | Description                      | Analogy                                    |
| ---- | ------------------- | -------------------------------- | ------------------------------------------ |
| 1    | Check `.vcs` exists | Ensure in repo                   | “Am I in the right photo album?”           |
| 2    | Get current commit  | Start at latest commit           | “Start with the most recent photo”         |
| 3    | Check for commits   | Handle empty repo                | “Album is empty”                           |
| 4    | Traverse commits    | Walk parent links                | “Flip backward through photos”             |
| 5    | Print info          | Show hash, author, date, message | “Read caption and timestamp of each photo” |
 */