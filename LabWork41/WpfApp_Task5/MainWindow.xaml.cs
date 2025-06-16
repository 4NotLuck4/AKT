using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_Task5
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ColorAnimationUsingKeyFrames animation = new ColorAnimationUsingKeyFrames
            {
                Duration = TimeSpan.FromSeconds(3)
            };

            animation.KeyFrames.Add(new LinearColorKeyFrame(Colors.Red, KeyTime.FromPercent(0.0)));
            animation.KeyFrames.Add(new LinearColorKeyFrame(Colors.Yellow, KeyTime.FromPercent(0.25)));
            animation.KeyFrames.Add(new LinearColorKeyFrame(Colors.Green, KeyTime.FromPercent(0.5)));
            animation.KeyFrames.Add(new LinearColorKeyFrame(Colors.Blue, KeyTime.FromPercent(0.75)));
            animation.KeyFrames.Add(new LinearColorKeyFrame(Colors.Purple, KeyTime.FromPercent(1.0)));

            GradientBrush.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation);
        }
    }
}