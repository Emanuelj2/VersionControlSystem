using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionControlSystem.Repository;
using VersionControlSystem.Storage;

namespace VersionControlSystem.Commands
{
    internal class CommitCommand
    {
        public static void Execute(string message, string author = "User")
        {
            if(!Directory.Exists(Core.Constants.VCS_DIR))
            {
                Console.WriteLine("Not a VCS repository. Please initialize first.");
                return;
            }

            var index = IndexManager.Load();
            if(index.Count == 0)
            {
                Console.WriteLine("No changes staged for commit.");
                return;
            }
            string treeHash = TreeBuilder.CreateTree(index);
            var commit = CommitManager.CreateCommit(treeHash, message, author);
            ReferenceManager.UpdateHead(commit.Hash!);

            Console.WriteLine($"[{commit.Hash!.Substring(0, 7)}] {message}");
        }
    }
}
/*
 * 
 * git commit -m "your message"
 * 
 * 
| Step | Code Action          | Purpose                   | Analogy                             |
| ---- | -------------------- | ------------------------- | ----------------------------------- |
| 1    | Check repo existence | Ensure `.vcs` exists      | “Am I in my art studio?”            |
| 2    | Load index           | Get staged changes        | “Which drawings are ready to save?” |
| 3    | Create tree          | Build snapshot            | “Take a photo of your progress”     |
| 4    | Create commit        | Record a new version      | “Write in your art journal”         |
| 5    | Update HEAD          | Move branch to new commit | “Mark this as your latest work”     |
| 6    | Print message        | Confirm success           | “Label the new photo”               |

*/