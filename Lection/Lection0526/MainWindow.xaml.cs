using Microsoft.Win32;
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
//using System.Windows

namespace Lection0526
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Закрыть окно?", 
                "Закрытие",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new();
            { //Ctrl+O
                dialog.Filter = "текстовые файлы|*.txt;*.html;*.csv|все файлы|*.*";
                dialog.Title = "Выберите имя файла"; // Заголовок проводника
                dialog.FilterIndex = 2;
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // открыть сразу чтото
            };
            dialog.InitialDirectory = Environment.CurrentDirectory;
            //dialog.InitialDirectory = Path.Combine(@"c:", "Temp", "ispp31"); //нужна библиотека ...
            dialog.Multiselect = true; // несколько сразу

            dialog.ShowDialog();

            var fileName = dialog.FileName; //если одно окно
            var fileNames = dialog.FileNames;//если несколько окон // только для OpenFileDialog
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new()  //Ctrl+S
            {
                Filter = "текстовые файлы|*.txt;*.html;*.csv|все файлы|*.*",
                Title = "Выберите имя файла", // Заголовок проводника
                FilterIndex = 2,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) // открыть сразу чтото
            }
            ;
            dialog.InitialDirectory = Environment.CurrentDirectory;
            //dialog.InitialDirectory = Path.Combine(@"c:", "Temp", "ispp31"); //нужна библиотека ...

            dialog.ShowDialog();

            var fileName = dialog.FileName; //если одно окно
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            //PrintDialog dialog = new();  //Ctrl+P

            //dialog.ShowDialog();

            //dialog.PrintVisual(panel, "print stackPanel");  //Canvas
            ////dialog.PrintDocument(...);
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog dialog = new();
            
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Owner = this;

            Hide();
            Close();

            if(dialog.ShowDialog() != true) 
                return;

            Show();
            Background = new SolidColorBrush(dialog.Color);


        }
    }
}