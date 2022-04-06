using Shell32;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoTime.UI.Helpers
{
    public static class DurationHelper
    {
        public static TimeSpan GetDurationOfVideoFiles(List<string> filePaths)
        {
            TimeSpan output = default;
            Shell shell = new Shell();

            foreach (string path in filePaths)
            {
                // http://www.levibotelho.com/development/get-the-length-of-a-video-in-c/
                Folder folder = shell.NameSpace(path);
                foreach (FolderItem2 item in folder.Items())
                {

                    if (item.Name.EndsWith(".mp4"))
                    {
                        output += TimeSpan.FromSeconds(item.ExtendedProperty("System.Media.Duration") / 10000000);
                    }
                }
            }
            return output;
        }
    }
}
