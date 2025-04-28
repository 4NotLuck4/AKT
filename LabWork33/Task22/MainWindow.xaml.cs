using System.Windows;
using System.Windows.Controls;

namespace Task22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> Users { get; set; }
        public List<string> Categories { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Categories = new List<string> { "email", "БД", "сайт" };

            Users = new List<User>
        {
            new User { Address = "user1@example.com", Login = "user1", Password = "password1", Category = "email", IsArchived = false },
            new User { Address = "user2@example.com", Login = "user2", Password = "password2", Category = "email", IsArchived = true },
            new User { Address = "user3@example.com", Login = "user3", Password = "password3", Category = "БД", IsArchived = false },
            new User { Address = "user4@example.com", Login = "user4", Password = "password4", Category = "сайт", IsArchived = true },
            new User { Address = "user5@example.com", Login = "user5", Password = "password5", Category = "БД", IsArchived = false }
        };

            userDataGrid.ItemsSource = Users;
        }

        private void CopyPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var user = button.DataContext as User;
            Clipboard.SetText(user.Password);
        }
    }
}