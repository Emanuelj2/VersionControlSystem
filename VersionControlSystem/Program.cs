
using VersionControlSystem.Commands;

namespace VersionControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                ShowUsage();
                return;
            }

            string command = args[0].ToLower();

            try
            {
                switch (command)
                {
                    case "init":
                        InitCommand.Execute();
                        break;

                    case "add":
                        if (args.Length < 2)
                        {
                            Console.WriteLine("Usage: simplevcs add <file>");
                            return;
                        }
                        AddCommand.Execute(args[1]);
                        break;

                    case "commit":
                        if (args.Length < 2)
                        {
                            Console.WriteLine("Usage: simplevcs commit <message>");
                            return;
                        }
                        string message = string.Join(" ", args.Skip(1));
                        CommitCommand.Execute(message);
                        break;

                    case "log":
                        LogCommand.Execute();
                        break;

                    case "status":
                        StatusCommand.Execute();
                        break;

                    default:
                        Console.WriteLine($"Unknown command: {command}");
                        ShowUsage();
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ShowUsage()
        {
            Console.WriteLine("SimpleVCS - A basic version control system");
            Console.WriteLine("\nUsage:");
            Console.WriteLine("  simplevcs init              Initialize a new repository");
            Console.WriteLine("  simplevcs add <file>        Add file to staging area");
            Console.WriteLine("  simplevcs commit <message>  Create a commit");
            Console.WriteLine("  simplevcs log               Show commit history");
            Console.WriteLine("  simplevcs status            Show repository status");
        }
    }
}