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

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> Categories { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
            Categories = new List<string> { "email", "БД", "сайт" }; // Категории
        }

        private void LoadUsers()
        {
            var users = new List<User>
            {
                new User { Address = "user1@example.com", Login = "user1", Password = "password1", IsArchived = false, Category = "email" },
                new User { Address = "user2@example.com", Login = "user2", Password = "password2", IsArchived = true, Category = "сайт" },
                new User { Address = "user3@example.com", Login = "user3", Password = "password3", IsArchived = false, Category = "БД" },
                new User { Address = "user4@example.com", Login = "user4", Password = "password4", IsArchived = true, Category = "email" },
                new User { Address = "user5@example.com", Login = "user5", Password = "password5", IsArchived = false, Category = "сайт" }
            };

            userDataGrid.ItemsSource = users;
        }

        private void CopyPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var user = button.DataContext as User;
            Clipboard.SetText(user.Password);
        }
    }

    public class User
    {
        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsArchived { get; set; }
        public string Category { get; set; }
    }
}