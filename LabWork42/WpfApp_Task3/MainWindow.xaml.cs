using System.Media;
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


namespace WpfApp_Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayBeep_Click(object sender, RoutedEventArgs e) => SystemSounds.Beep.Play();

        private void PlaySound1_Click(object sender, RoutedEventArgs e)
        {
            var player = new SoundPlayer("sound1.wav");
            player.Play();
        }

        private void PlaySound2_Click(object sender, RoutedEventArgs e)
        {
            var player = new MediaPlayer();
            player.Open(new Uri("sound2.mp3", UriKind.Relative));
            player.Play();
        }
    }
}