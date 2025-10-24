using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionControlSystem.Core;
using VersionControlSystem.Storage;

namespace VersionControlSystem.Commands
{
    internal class AddCommand
    {
        public static void Execute(string path)
        {
            if(!Directory.Exists(Constants.VCS_DIR))
            {
                Console.WriteLine("Not a VCS repository. Please initialize first.");
                return;
            }

            if(!File.Exists(path))
            {
                Console.WriteLine($"File '{path}' does not exist.");
                return;
            }

            byte[] content = File.ReadAllBytes(path);
            string hash = HashUtility.ComputeHash(content);

            ObjectStore.SaveObject(hash, content);
            IndexManager.AddEntry(path, hash);

            Console.WriteLine($"Added '{path}' to staging area.");
        }
    }
}

/*
| Step | Code Action         | Purpose                 | Analogy                                |
| ---- | ------------------- | ----------------------- | -------------------------------------- |
| 1    | Check `.vcs` exists | Ensure inside repo      | “Check if the studio is ready”         |
| 2    | Verify file exists  | Ensure file is real     | “Find the photo to add”                |
| 3    | Read file bytes     | Load content            | “Scan the photo”                       |
| 4    | Compute hash        | Create unique ID        | “Label the photo with a fingerprint”   |
| 5    | Save object         | Store in `.vcs/objects` | “File it in your archive cabinet”      |
| 6    | Update index        | Stage for commit        | “Add to the album’s ‘to include’ list” |
| 7    | Print message       | Confirm success         | “Tell the user the photo’s ready”      | 
*/
