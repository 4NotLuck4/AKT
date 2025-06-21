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

namespace Task3_PingPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameManager _gameManager;

        public MainWindow()
        {
            InitializeComponent();
            _gameManager = new GameManager(gameCanvas, paddle, ball);
            _gameManager.StartGame();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            _gameManager.HandleKeyPress(e.Key);
        }
    }
}