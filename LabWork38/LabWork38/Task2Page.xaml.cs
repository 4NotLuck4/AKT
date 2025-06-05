using System.IO;

namespace LabWork38;

public partial class Task2Page : ContentPage
{
    DirectoryInfo _directory = new(@"Y:\МДК.01.01\Images");
    IEnumerable<FileInfo> _files;
    public int PageSize { get; set; } = 5;
    public int CurrentPage { get; set; } = 1;
    public int PagesCount { get; set; }

    public Task2Page()
	{
		InitializeComponent();
        _files = _directory.GetFiles().AsEnumerable();
        PageSize = int.Parse(PageSizeEntry.Text);
        SetFiles();
    }

    private void SetFiles()
    {
        PageCountEntry.Text = CurrentPage.ToString();

        var files = _files;

        if (!string.IsNullOrEmpty(FilterEntry.Text))
            files = files.Where(f => f.Name.Contains(FilterEntry.Text));

        PagesCount = (int)Math.Ceiling(files.Count() / (double)PageSize);

        files = files
            .OrderBy(f => f.Name)
            .Skip(PageSize * (CurrentPage - 1))
            .Take(PageSize * CurrentPage).AsEnumerable();

        BackPageButton.IsEnabled = FirstPageButton.IsEnabled = CurrentPage > 1;
        ForwardPageButton.IsEnabled = LastPageButton.IsEnabled = CurrentPage < PagesCount;

        FilesListView.ItemsSource = files;

        CountLabel.Text = $"Показано {CurrentPage} из {PagesCount} страниц";
    }

    private void BackPageButton_Clicked(object sender, EventArgs e)
    {
        CurrentPage--;
        
        SetFiles();
    }

    private void ForwardPageButton_Clicked(object sender, EventArgs e)
    {
        CurrentPage++;
        
        SetFiles();
    }

    private void FirstPageButton_Clicked(object sender, EventArgs e)
    {
        CurrentPage = 1;
        SetFiles();
    }

    private void LastPageButton_Clicked(object sender, EventArgs e)
    {
        CurrentPage = PagesCount;
        SetFiles();
    }

    private void PageCountEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        CurrentPage = int.Parse(PageCountEntry.Text);
        if (CurrentPage >  PagesCount)
            CurrentPage = PagesCount;
        if (CurrentPage <= 0)
            CurrentPage = 1;
        SetFiles();
    }

    private void FilterEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        CurrentPage = 1;
        SetFiles();
    }

    private void PageSizeEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(PageSizeEntry.Text))
        {
            PageSize = int.Parse(PageSizeEntry.Text);
            CurrentPage = 1;
            SetFiles();
        }
    }
}