using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shell32;


namespace VideoTime.UI
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Read CMD Input
            string filePath = Path.GetFullPath(args[0]);

            // Define types needed.
            TimeSpan duration = default;
            List<string> filePaths = default;
            // Create a new shell object
            Shell shell = new Shell();

            try
            {
                filePaths = GetAllDirectoriesFromFolder(filePath);
            }
            catch (DirectoryNotFoundException directoryNotFound)
            {
                Console.WriteLine(directoryNotFound.Message);
                return;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            foreach (string path in filePaths)
            {
                // http://www.levibotelho.com/development/get-the-length-of-a-video-in-c/
                Folder folder = shell.NameSpace(path);
                foreach (FolderItem2 item in folder.Items())
                {
                    
                    if (item.Name.EndsWith(".mp4"))
                    {
                        duration += TimeSpan.FromSeconds(item.ExtendedProperty("System.Media.Duration") / 10000000);
                    }
                }
            }
            Console.WriteLine($"The total video duration for the path is: {duration}");
        }
        public static List<string> GetAllDirectoriesFromFolder(string parentFolder)
        {
            List<string> directories = default;
            
            directories = Directory.GetDirectories(parentFolder, "*", searchOption: SearchOption.AllDirectories).ToList();
            directories.Add(parentFolder);
            return directories;
        }
    }
}
