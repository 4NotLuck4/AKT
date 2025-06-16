using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp_Task4_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            LoadPlaylist();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateTime;
        }

        private void LoadPlaylist()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
            }
        }


        //var dialog = new FolderBrowserDialog();
        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        Playlist.ItemsSource = Directory.GetFiles(dialog.SelectedPath)
        //            .Where(f => f.EndsWith(".mp3") || f.EndsWith(".mp4") || f.EndsWith(".wmv"));
        //    }


        private void Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Playlist.SelectedItem != null)
            {
                MediaPlayer.Source = new Uri(Playlist.SelectedItem.ToString());
                Play_Click(null, null);
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e) => MediaPlayer.Play();
        private void Pause_Click(object sender, RoutedEventArgs e) => MediaPlayer.Pause();
        private void Stop_Click(object sender, RoutedEventArgs e) => MediaPlayer.Stop();

        private void UpdateTime(object sender, EventArgs e)
        {
            if (MediaPlayer.NaturalDuration.HasTimeSpan)
            {
                TimeText.Text = $"{MediaPlayer.Position:mm\\:ss} / {MediaPlayer.NaturalDuration.TimeSpan:mm\\:ss}";
            }
        }
    }
}