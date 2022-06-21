using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public BindingList<string> outputMessages = new BindingList<string>();
        public MainWindow()
        {
            InitializeComponent();
            outPutList.ItemsSource = outputMessages;
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
            TimeSpan duration = default;
            List<string> filePaths = PathHelper.ResolveDirectoriesPath(pathText.Text);

            foreach (string path in filePaths)
            {
                outputMessages.Add(path);
                outPutList.Items.Refresh();
                duration += DurationHelper.GetDurationOfVideoFiles(path);
            }
            resultText.Text = $"The folder contains {Math.Floor( duration.TotalHours )} Hours of video.";

        }
    }
}
