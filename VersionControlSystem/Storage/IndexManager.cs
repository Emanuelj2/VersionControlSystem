using System.Text.Json;
using VersionControlSystem.Models;

namespace VersionControlSystem.Storage
{
    internal class IndexManager
    {
        /*
         This class manages the index (staging area) in a version control system
         similar to how Git uses an index to track which files are staged before committing.

         The class can:
         Load the current index from a JSON file.
         Save index entries to that file.
         Add or update an entry (a file path + hash pair).
         */

        //This method saves the index entries to the index file in JSON format
        public static List<IndexEntry> Load()
        {
            if(!File.Exists(Core.Constants.INDEX_FILE))
            {
                return new List<IndexEntry>(); //return an empty list
            }
            string json = File.ReadAllText(Core.Constants.INDEX_FILE);
            return JsonSerializer.Deserialize<List<IndexEntry>>(json) ?? new List<IndexEntry>();
        }

        //This method loads the index entries from the index file in JSON format
        public static void Save(List<IndexEntry> entries)
        {
            string json = JsonSerializer.Serialize(entries);
            File.WriteAllText(Core.Constants.INDEX_FILE, json);
        }

        public static void AddEntry(string path, string hash)
        {
            var index = Load();
            var existingEntry = index.Find(e => e.Path == path);

            if(existingEntry != null)
            {
                existingEntry.Hash = hash;
            }
            else
            {
                index.Add(new IndexEntry { Path = path, Hash = hash });
            }
            Save(index);
        }
    }
}
/*
 Load() → read .git/index

 AddEntry() → stage a file (git add file)

 Save() → update .git/index on disk
*/
