using Shell32;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoTime.GUI.Helpers
{
    public static class DurationHelper
    {
   
        public static TimeSpan GetDurationOfVideoFiles(string path)
        {
            TimeSpan output = default;
            Shell shell = new Shell();
            // http://www.levibotelho.com/development/get-the-length-of-a-video-in-c/
            Folder folder = shell.NameSpace(path);
            foreach (FolderItem2 item in folder.Items())
            {
                if (item.Name.EndsWith(".mp4"))
                {
                    output += TimeSpan.FromSeconds(item.ExtendedProperty("System.Media.Duration") / 10000000);
                }
            }
            return output;
        }
    }
}
