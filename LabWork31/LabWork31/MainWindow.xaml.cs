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

namespace LabWork31
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

        private void PasswordBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TextBlockPasswordLegth.Text = $"Длина пароля{PasswordBoxPassword.Password.Length}";
        }

        private void TextBoxInfo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBlockInfoLegth.Text = $"Осталось символов: {200 - TextBoxInfo.Text.Length}";
        }

        private void DatePicterBirthday_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DatePicterBirthday.SelectedDate.HasValue)
            {
                //DateTimeBirthDate = DatePicterBirthday.SelectedDate.Value;
            }
        }
    }
}