using DatabaseLibrary;
using System.Diagnostics;
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

namespace DatabaseAp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDatabase _database;
        public MainWindow()
        {
            InitializeComponent();

            _database = new SqlDatabase(
                server: "mssql",
                database: "ispp3102",
                userName: "ispp3102",
                password: "3102");

            Debug.WriteLine(_database.ToString());
        }


    }
}