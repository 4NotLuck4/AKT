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

namespace Lection0425_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UserComboBox.Items.Clear();
            UserComboBox.Items.Add("admin");
            UserComboBox.Items.Add("user");
            UserComboBox.Items.Add("user");
            UserComboBox.Items.Add("user");
            UserComboBox.Items.Add("user");
            UserComboBox.Items.Remove("user");
            UserComboBox.Items.RemoveAt(0);
            UserComboBox.Items.RemoveAt(UserComboBox.Items.Count - 1);
            UserComboBox.Items.Insert(0, "test");

            var files = new DirectoryInfo(@"Y:\МДК.01.01").GetFiles();
            FilesListBox.ItemsSource = files;
            FilesDataGrid.ItemsSource = files;
            FilesListView.ItemsSource = files;
        }

        private void FilesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var removed = e.RemovedItems;
            var added = e.AddedItems;
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {

            FilesListView.ItemTemplate =
                (DataTemplate)FindResource("FileFullInfoTemplate");
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            var file = (e.Source as Button).DataContext as FileInfo;
            MessageBox.Show(file.FullName);
        }
    }
}