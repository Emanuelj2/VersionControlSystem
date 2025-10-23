using System.Text;
using System.Text.Json;
using VersionControlSystem.Core;
using VersionControlSystem.Models;
using VersionControlSystem.Storage;

namespace VersionControlSystem.Repository
{
    internal class CommitManager
    {
        public static Commit CreateCommit(string treeHash, string message, string author)
        {
            string parentHash = ReferenceManager.GetCurrentCommitHash();
            Commit commit = new Commit
            {
                TreeHash = treeHash,
                ParentHash = parentHash,
                Message = message,
                Author = author,
                Timestamp = DateTime.UtcNow
            };

            string commitData = JsonSerializer.Serialize(commit); //cnvert data to json fromat
            commit.Hash = HashUtility.ComputeHash(Encoding.UTF8.GetBytes(commitData)); //compute hash of the commit data

            ObjectStore.SaveObject(commit.Hash, commitData); //save the commit object to the object store

            return commit;
        }


        //fetch a commit object from the object store using its hash
        //return null if the commit is not found
        //return the Commit object if found
        //if the object is found, deserialize the json data back into a Commit object
        public static Commit LoadCommit(string hash)
        {
            string json = ObjectStore.LoadObjectAsString(hash); //load the commit data from the object store
            if (json == null)
            {
                return null!; //hash not found
            }
            return JsonSerializer.Deserialize<Commit>(json)!; //deserialize the json data back into a Commit object

        }
    }
}
