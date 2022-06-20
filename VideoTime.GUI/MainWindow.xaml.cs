using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideoTime.GUI.Helpers;

namespace VideoTime.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO: Need a stackpanel to show folders iterated, and unauthorized folders
        public MainWindow()
        {
            InitializeComponent();
        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                pathText.Text = dialog.SelectedPath;
            }
        }

        private void GetDuration_Click(object sender, RoutedEventArgs e)
        {
            List<string> filePaths = PathHelper.ResolveDirectoriesPath(pathText.Text);

            TimeSpan duration = DurationHelper.GetDurationOfVideoFiles(filePaths);

            resultText.Text = $"The folder contains {Math.Floor( duration.TotalHours )} Hours of video.";

        }
    }
}
