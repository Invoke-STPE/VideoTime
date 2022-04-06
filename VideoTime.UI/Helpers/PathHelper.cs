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
            string directoryPath = ResolveAbsolutePath(path);

            return GetAllDirectoryPathsFromFolder(directoryPath);

        }
        private static string ResolveAbsolutePath(string cmdArgument)
        {
            return Path.GetFullPath(cmdArgument);
        }
        private static List<string> GetAllDirectoryPathsFromFolder(string parentFolder)
        {
            List<string> directories = Directory.GetDirectories(parentFolder, "*", searchOption: SearchOption.AllDirectories).ToList();
            directories.Add(parentFolder);
            return directories;
        }
    }
}
