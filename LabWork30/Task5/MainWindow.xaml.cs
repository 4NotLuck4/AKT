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

namespace Task5
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
        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(ApplyColorCheckBox.IsChecked == true)
            {
                UpdateBackgroundColor();
            }
        }

        private void ApplyColorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateBackgroundColor();
        }

        private void ApplyColorCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.White;
        }
        private void UpdateBackgroundColor()
        {
            byte r = (byte)RedSlider.Value;
            byte g = (byte)GreenSlider.Value;
            byte b = (byte)BlueSlider.Value;
            this.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

    }
}