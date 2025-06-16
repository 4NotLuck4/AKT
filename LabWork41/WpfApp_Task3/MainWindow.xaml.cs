using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
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
        private void AnimateButton_Loaded(object sender, RoutedEventArgs e)
        {
            // Анимация текста
            DoubleAnimation FontSizeAnimation = new DoubleAnimation
            {
                From = 14,
                To = 28,
                AutoReverse = true,
                Duration = TimeSpan.FromSeconds(0.5),
                RepeatBehavior = new RepeatBehavior(2)
            };

            // Анимация масштаба
            DoubleAnimation ScaleAnimation = new DoubleAnimation
            {
                From = 1,
                To = 2,
                AutoReverse = true,
                Duration = TimeSpan.FromSeconds(0.5),
                RepeatBehavior = new RepeatBehavior(2)
            };
            AnimateButton.BeginAnimation(FontSizeProperty, FontSizeAnimation);
            ScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, ScaleAnimation);
            ScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, ScaleAnimation);
        }
    }
}