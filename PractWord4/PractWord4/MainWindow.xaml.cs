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

namespace PractWord4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GamesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GamesDataGrid.SelectedItem is Game selectedGame)
            {
                NameTextBox.Text = selectedGame.Name;
                DescriptionTextBox.Text = selectedGame.Description;
                PriceTextBox.Text = selectedGame.Price.ToString();
                SaleTextBox.Text = selectedGame.Sale.ToString();
            }
        }
    }
}