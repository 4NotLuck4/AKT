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

namespace WpfApp_Task1
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

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (MenuPanel.Width > 0)
                animation.To = 0;
            else
                animation.To = 200;

            MenuPanel.BeginAnimation(WidthProperty, animation);
        }
    }
}