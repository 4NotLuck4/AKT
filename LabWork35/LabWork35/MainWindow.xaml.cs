using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LabWork35
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

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new()   //Ctrl+O
            {
                Filter = "текстовые файлы|*.txt;*.html;*.css;*.js;*.sql",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (dialog.ShowDialog() != true)
                return;

            TextBox.Text = File.ReadAllText(dialog.FileName);
            Title = dialog.FileName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new()
            {
                Filter = "текстовые файлы|*.txt;*.html;*.css;*.js;*.sql",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (dialog.ShowDialog() != true)
                return;

            File.WriteAllText(dialog.FileName, TextBox.Text);
            MessageBox.Show("Файл сохранен");
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
    }
}