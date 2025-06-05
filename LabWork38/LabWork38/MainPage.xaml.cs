using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace LabWork38
{
    public partial class MainPage : ContentPage
    {
        DirectoryInfo _directory = new(@"Y:\МДК.01.01");
        IEnumerable<FileInfo> _files;
        public int PageSize { get; set; } = 5;
        public int CurrentPage { get; set; } = 1;
        public int PagesCount { get; set; }

        public MainPage()
        {
            InitializeComponent();
            _files = _directory.GetFiles().AsEnumerable();
            PagesCount = (int)Math.Ceiling(_files.Count() / (double)PageSize);
            SetFiles();
        }

        private void SetFiles()
        {
            if (CurrentPage == PagesCount)
                ShowMoreButton.IsEnabled = false;

            var files = _files
                .OrderBy(f => f.Name)
                .Take(PageSize * CurrentPage);

            FilesListView.ItemsSource = files;

            CountLabel.Text = $"Показано {files.Count()} из {_files.Count()} записей. Всего страниц: {PagesCount}";
        }

        private void ShowMoreButton_Clicked(object sender, EventArgs e)
        {
            CurrentPage++;
            SetFiles();
        }

        private void SizePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageSize = int.Parse(SizePicker.SelectedItem.ToString());
            CurrentPage = 1;
            SetFiles();
        }
    }

}
