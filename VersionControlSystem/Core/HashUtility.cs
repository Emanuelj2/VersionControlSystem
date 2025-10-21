using System;
//using System.Security.Cryptography;

namespace VersionControlSystem.Core
{
    internal class HashUtility
    {
        public static string ComputeHash(byte[] data)
        {
            using(var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(data);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
/*
 -This class provides a utility method to generate a unique hash for any piece of data.
 -version control system uses SHA-256 (a more modern and secure algorithm).
 -The ComputeHash method takes a byte array as input, computes its SHA-256 hash, and returns the hash as a lowercase hexadecimal string.
  This hash can be used to uniquely identify files, commits, or other objects in the version control system, ensuring data integrity and enabling efficient storage and retrieval.
*/