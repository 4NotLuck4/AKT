using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadFiles();
        }
        private void LoadFiles()
        {
            string[] files = Directory.GetFiles("C:"); // Укажите путь к каталогу
            var fileList = new List<FileInfo>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                fileList.Add(fileInfo);
            }

            fileListView.ItemsSource = fileList;
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var fileInfo = button.DataContext as FileInfo;
            MessageBox.Show($"Полное имя файла: {fileInfo.FullName}");
        }
    }
}