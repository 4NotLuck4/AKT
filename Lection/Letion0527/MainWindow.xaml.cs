using System.Windows;

namespace Letion0527
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public  Cat MyCat { get; set; }

        public DateTime CurrentDate {  get; set; } = DateTime.Now;
        public MainWindow()
        {
            InitializeComponent();

            Cat cat = new Cat() { Id = 1, Name = "tum tum tum sahur", Age = 7 };

            MyCat = new Cat() { Id = 2, Name = "crocodile bombardino", Age = 5 };
            DataContext = this;

            NameTextBox.DataContext = cat.Id;
            DateTime date = DateTime.Now;
            YearTextBox.DataContext = date;
        }
    }
}