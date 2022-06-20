using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VideoTime.UI.Helpers
{
    public static class PathHelper
    {

        public static List<string> ResolveDirectoriesPath(string path)
        {
            List<string> test = GetAllDirectoryPathsFromFolder(path);
            return test;

        }

        // Have to loop through the return of GetDirectories, else I cannot continue if an exception is hit.
        // http://www.blackwasp.co.uk/FolderRecursion.aspx
        private static List<string> GetAllDirectoryPathsFromFolder(string path)
        {
            List<string> directoryPaths = new List<string>();
            try
            {
                foreach (string folder in Directory.GetDirectories(path))
                {
                    Console.WriteLine($"{folder}");
                    directoryPaths.Add(folder);
                    GetAllDirectoryPathsFromFolder(folder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Unauthorized Access found");
            }
            return directoryPaths;
        }
    }
}
