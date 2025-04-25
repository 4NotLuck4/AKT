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

namespace LabWork29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool MyProperty { get; set; } = true;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        //private void CheckLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
        //    {
        //        LabelVariability.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        LabelVariability.Visibility = Visibility.Hidden;
        //    }
        //}
    }
}