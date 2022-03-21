﻿using System;
using System.IO;
using Shell32;


namespace VideoTime.UI
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Read CMD Input
            string filePath = Path.GetFullPath(args[1]);

            // Create a new shell object
            var shell = new Shell();
            var folder = shell.NameSpace(filePath);
            foreach (FolderItem2 item in folder.Items())
            {

                if (item.Name == "sample_file.mp4")
                {
                    Console.WriteLine(TimeSpan.FromSeconds(item.ExtendedProperty("System.Media.Duration") / 10000000));
                }
            }

            }
    }
}
