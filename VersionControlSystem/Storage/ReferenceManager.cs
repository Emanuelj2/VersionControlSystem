namespace VersionControlSystem.Storage
{
    internal class ReferenceManager
    {

        //The GetCurrentCommitHash() function retrieves the current commit hash
        //(the ID of the most recent commit) in a version control system
        //(similar to how Git keeps track of commits).
        public static string GetCurrentCommitHash()
        {
            if(!File.Exists(Core.Constants.HEAD_FILE))
            {
                throw new FileNotFoundException("HEAD file not found.");
            }
            string headContent = File.ReadAllText(Core.Constants.HEAD_FILE).Trim();

            if(headContent.StartsWith("ref: "))
            {
                string refPath = headContent.Substring(5).Trim();
                string fullRefPath = Path.Combine(Core.Constants.VCS_DIR, refPath.Replace('/', Path.DirectorySeparatorChar));
                
                if(File.Exists(fullRefPath))
                {
                    return File.ReadAllText(fullRefPath).Trim();
                }
                return null!;
            }
            return headContent;
        }

        public static void UpdateHead(string commitHash)
        {
            string headContent = File.ReadAllText(Core.Constants.HEAD_FILE).Trim();
            if(headContent.StartsWith("ref: "))
            {
                string refPath = headContent.Substring(5).Trim();
                string fullRefPath = Path.Combine(Core.Constants.VCS_DIR, refPath.Replace('/', Path.DirectorySeparatorChar));
                Directory.CreateDirectory(Path.GetDirectoryName(fullRefPath)!);
                File.WriteAllText(fullRefPath, commitHash);
            }
            else
            {
                File.WriteAllText(Core.Constants.HEAD_FILE, commitHash);
            }
        }

        public static string GetCurrentBranch()
        {
            if(!File.Exists(Core.Constants.HEAD_FILE))
            {
                return Core.Constants.DEFAULT_BRANCH;
            }
            string headContent = File.ReadAllText(Core.Constants.HEAD_FILE).Trim();
            if(headContent.StartsWith("ref: refs/heads/"))
            {
                return headContent.Substring("ref: refs/heads/".Length);
            }
            return "detached HEAD";
        }

    }
}
