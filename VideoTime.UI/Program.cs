using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shell32;
using VideoTime.UI.Helpers;


namespace VideoTime.UI
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //string path = @"E:\Courses\IAmTimCorey";
            string path = @"E:\Courses\IAmTimCorey";
            List<string> filePaths = PathHelper.ResolveDirectoriesPath(path);

            TimeSpan duration = DurationHelper.GetDurationOfVideoFiles(filePaths);



            Console.WriteLine($"The total video duration for the path is: {duration}");

        }

        
       
    }
}
