using VersionControlSystem.Storage;

namespace VersionControlSystem.Commands
{
    internal class StatusCommand
    {
        public static void Execute()
        {
            //check if you are in a VCS repository
            if (!Directory.Exists(Core.Constants.VCS_DIR))
            {
                Console.WriteLine("Not a VCS repository. Please initialize first.");
                return;
            }

            var index = IndexManager.Load();
            string branch = ReferenceManager.GetCurrentBranch();

            Console.WriteLine($"On branch {branch}");
            Console.WriteLine($"\nStaged files ({index.Count}):");

            foreach (var entry in index)
            {
                Console.WriteLine($"  {entry.Path}");
            }

            if(index.Count == 0)
            {
                Console.WriteLine("  (no files staged)");
            }

        }
    }
}
/*
| Step | Code Action         | Purpose               | Analogy                      |
| ---- | ------------------- | --------------------- | ---------------------------- |
| 1    | Check `.vcs` exists | Ensure inside repo    | “Are we in the theater?”     |
| 2    | Load index          | Get staged files      | “See which actors are ready” |
| 3    | Get current branch  | Know where we are     | “Which stage are we on?”     |
| 4    | Print header        | Show branch + summary | “Announce the show details”  |
| 5    | Print files         | List all staged items | “List the cast members”      |
| 6    | Handle empty index  | Show no files staged  | “No actors rehearsing”       |
*/
