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

namespace WpfApp_Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> images = new List<string>();
        private int currentIndex = 0;
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.3);
            timer.Tick += Timer_Tick;
        }

        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                images = Directory.GetFiles(dialog.SelectedPath, "*.*")
                    .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".bmp"))
                    .Take(5).ToList();

                if (images.Count > 0)
                {
                    currentIndex = 0;
                    LoadImage();
                    timer.Start();
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % images.Count;
            LoadImage();
        }

        private void LoadImage()
        {
            if (images.Count == 0) return;
            DisplayImage.Source = new BitmapImage(new Uri(images[currentIndex]));
        }
    }
}