namespace Task1
{
    public partial class MainPage : ContentPage
    {
        private DirectoryInfo _directory;
        private string _sizeFilterMode = "Все файлы";

        public MainPage()
        {
            InitializeComponent();

            _directory = new DirectoryInfo(@"Y:/МДК.01.01");
            FilterFiles();
        }

        private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterFiles();
        }

        private void FilterFiles()
        {
            var files = _directory.GetFiles().ToList();
            var text = SearchEntry.Text;

            if (!string.IsNullOrEmpty(text))
                files = files.Where(file => file.Name.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();

            if (_sizeFilterMode != "Все файлы" && SizeEntry.Text.Length > 0)
                switch (_sizeFilterMode)
                {
                    case "Больше или равно":
                        files = files.Where(file => file.Length >= int.Parse(SizeEntry.Text)).ToList();
                        break;
                    case "Меньше или равно":
                        files = files.Where(file => file.Length <= int.Parse(SizeEntry.Text)).ToList();
                        break;
                }

            if (GreaterOrEqualCheckBox.IsChecked && !string.IsNullOrWhiteSpace(GreaterOrEqualEntry.Text))
                files = files.Where(file => file.Length >= int.Parse(GreaterOrEqualEntry.Text)).ToList();

            if (LessOrEqualCheckBox.IsChecked && !string.IsNullOrWhiteSpace(LessOrEqualEntry.Text))
                files = files.Where(file => file.Length <= int.Parse(LessOrEqualEntry.Text)).ToList();

            SetFiles(files);
        }

        private void SetFiles(List<FileInfo> files)
        {
            FilesListView.ItemsSource = files;
            CountLabel.Text = $"Показано {files.Count} из {_directory.GetFiles().Length} записей";
        }

        private void ResetFilterButton_Clicked(object sender, EventArgs e)
        {
            SearchEntry.Text = string.Empty;

            FilterFiles();
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            _sizeFilterMode = (string)radioButton.Content;
            FilterFiles();
        }

        private void SizeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterFiles();
        }

        private void GreaterOrEqualCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            FilterFiles();
        }

        private void GreaterOrEqualEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterFiles();
        }

        private void LessOrEqualEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterFiles();
        }

        private void LessOrEqualCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            FilterFiles();
        }

        private void SizeChanged_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterFiles();
        }
    }

}
