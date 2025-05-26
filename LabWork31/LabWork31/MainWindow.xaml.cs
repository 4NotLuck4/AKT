//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace LabWork31
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//        }

//        private void PasswordBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
//        {
//            TextBlockPasswordLegth.Text = $"Длина пароля{PasswordBoxPassword.Password.Length}";
//        }

//        private void TextBoxInfo_TextChanged(object sender, TextChangedEventArgs e)
//        {
//            TextBlockInfoLegth.Text = $"Осталось символов: {200 - TextBoxInfo.Text.Length}";
//        }

//        private void DatePicterBirthday_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
//        {
//            if(DatePicterBirthday.SelectedDate.HasValue)
//            {
//                //DateTimeBirthDate = DatePicterBirthday.SelectedDate.Value;
//            }
//        }
//    }
//}

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
        private const int MaxAboutChars = 200;
        private string password = string.Empty;
        private string confirmPassword = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            password = ((PasswordBox)sender).Password;
            TextBlockPasswordChangen.Text = $"Длина пароля: {password.Length}";
            ValidatePassword();
        }

        private void PasswordBoxConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            confirmPassword = ((PasswordBox)sender).Password;
            ValidatePassword();
        }

        private void ValidatePassword()
        {
            if (password != confirmPassword)
            {
                PasswordBoxConfirm.BorderBrush = Brushes.Red;
                TextBlockError.Text = "Пароли не совпадают!";
            }
            else
            {
                PasswordBoxConfirm.BorderBrush = Brushes.Gray;
                TextBlockError.Text = string.Empty;
            }
        }

        private void TextBoxAbout_TextChanged(object sender, TextChangedEventArgs e)
        {
            int remainingChars = MaxAboutChars - TextBoxAbout.Text.Length;
            TextBlockRemainingChars.Text = $"Осталось символов: {remainingChars}";
        }

        private void DatePickerBirthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePickerBirthDate.SelectedDate.HasValue)
            {
                DateTime birthDate = DatePickerBirthDate.SelectedDate.Value;
                int age = DateTime.Now.Year - birthDate.Year;
                if (birthDate > DateTime.Now.AddYears(-age)) age--;
                TextBlockAge.Text = $"Возраст: {age} лет";
            }
        }

        private void SliderExperience_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int experience = (int)SliderExperience.Value;
            string experienceText = experience == 1 ? "год" : experience < 5 ? "года" : "лет";
            TextBoxExperience.Text = $"Стаж: {experience} {experienceText}";
        }

        private void CalendarMeetings_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerBirthDate.SelectedDate.HasValue)
            {
                CalendarMeetings.SelectedDates.Add(DatePickerBirthDate.SelectedDate.Value);
            }
        }
    }
}