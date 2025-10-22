using VersionControlSystem.Core;

namespace VersionControlSystem.Storage
{
    internal class ObjectStore
    {
        // This class would handle storing and retrieving objects (files, commits, trees) in the version control system.
        // It would use the Constants defined in Core/Constants.cs for directory paths and manage the serialization/deserialization of objects.

        public static string GetObjectPath(string hash)
        {
            return Path.Combine(Constants.OBJECTS_DIR, hash.Substring(0, 2), hash.Substring(2));
        }

        //Saving Binary Data (Any non-text content, EXAMPLE: .png and .jpg)
        public static void SaveObject(string hash, byte[] data)
        {
            var objectPath = GetObjectPath(hash);
            Directory.CreateDirectory(Path.GetDirectoryName(objectPath)!);
            File.WriteAllBytes(objectPath, data);
        }

        //Saving Text Data
        public static void SaveObject(string hash, string data)
        {
            var objectPath = GetObjectPath(hash);
            Directory.CreateDirectory(Path.GetDirectoryName(objectPath)!);
            File.WriteAllText(objectPath, data);
        }

        //Loading Text Data
        public static string LoadObjectAsString(string hash)
        {
            var objectpath = GetObjectPath(hash);
            if(File.Exists(objectpath))
            {
                return null!;
            }
            return File.ReadAllText(objectpath);
        }

        //Loading Binary Data
        public static byte[] LoadObjectAsBytes(string hash)
        {
            var objectpath = GetObjectPath(hash);
            if(File.Exists(objectpath))
            {
                return null!;
            }
            return File.ReadAllBytes(objectpath);
        }

    }
}
