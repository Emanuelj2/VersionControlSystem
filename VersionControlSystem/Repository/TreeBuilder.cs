using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using VersionControlSystem.Core;
using VersionControlSystem.Models;
using VersionControlSystem.Storage;

namespace VersionControlSystem.Repository
{
    internal class TreeBuilder
    {
        public static string CreateTree(List<IndexEntry> index)
        { 
            string treeData = JsonSerializer.Serialize(index);
            string treeHash = HashUtility.ComputeHash(Encoding.UTF8.GetBytes(treeData));
            ObjectStore.SaveObject(treeHash, treeData);
            return treeHash;
        }
    }
}
/*
 
 EXAMPLE INPUT:
 [ { "File": "main.cs", "Hash": "abc123" }, { "File": "readme.txt", "Hash": "def456" } ]
 TO 
"[{\"File\":\"main.cs\",\"Hash\":\"abc123\"},{\"File\":\"readme.txt\",\"Hash\":\"def456\"}]"

*/

/*
| Step | Code Line       | What It Does             | Analogy                            |
| ---- | --------------- | ------------------------ | ---------------------------------- |
| 1    | Serialize index | Converts files into JSON | Write down box contents            |
| 2    | ComputeHash     | Creates unique hash      | Stamp box with unique ID           |
| 3    | SaveObject      | Saves snapshot           | Store sealed box in warehouse      |
| 4    | Return hash     | Returns unique ID        | Give you the box’s tracking number |
 
*/