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
            UpdatePen();
        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Файлы изображений|*.jpg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                inkCanvas.Background = new ImageBrush(new BitmapImage(new Uri(openFileDialog.FileName)));
            }
        }

        private void UpdatePen()
        {
            inkCanvas.DefaultDrawingAttributes.Color = ((SolidColorBrush)ColorComboBox.SelectedValue).Color;
            inkCanvas.DefaultDrawingAttributes.Width =
            inkCanvas.DefaultDrawingAttributes.Height = double.Parse((string)((ComboBoxItem)SizeComboBox.SelectedItem).Content);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdatePen();
    }
}