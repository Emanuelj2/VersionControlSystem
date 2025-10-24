using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VersionControlSystem.Core;

namespace VersionControlSystem.Commands
{
    internal class InitCommand
    {
        public static void Execute()
        {
            if(Directory.Exists(Constants.VCS_DIR))
            {
                Console.WriteLine("Repository already initialized.");
                return;
            }
            Directory.CreateDirectory(Constants.VCS_DIR);
            Directory.CreateDirectory(Constants.OBJECTS_DIR);
            Directory.CreateDirectory(Constants.REFS_DIR);
            Directory.CreateDirectory(Constants.HEADS_DIR);

            File.WriteAllText(Constants.HEAD_FILE, $"ref: refs/heads/{Constants.DEFAULT_BRANCH}");

            Console.WriteLine("Initialized empty VCS repository in " + Path.GetFullPath(Constants.VCS_DIR));
        }
    }
}

/*
 * responsible for initializing a new version control 
 * repository, much like how git init works in Git
 * 
 * 
| Step | Code Action                   | Purpose                      |
| ---- | ----------------------------- | ---------------------------- |
| 1    | Check if `.vcs` folder exists | Prevent re-initialization    |
| 2    | Create folder structure       | Prepare internal directories |
| 3    | Write HEAD file               | Track the current branch     |
| 4    | Print confirmation            | Inform user of success       |

*/