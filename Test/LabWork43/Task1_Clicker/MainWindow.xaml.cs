using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;

namespace Task1_Clicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly GameLogic _gameLogic;

        public MainWindow()
        {
            InitializeComponent();
            _gameLogic = new GameLogic();

            SetupUI();
            SetupEventHandlers();
            StartGame();
        }

        private void SetupUI()
        {
            // Настройка изображения печеньки
            var cookieImage = new ImageBrush(new BitmapImage(new System.Uri("1.png", System.UriKind.Relative)));
            Cookie.Fill = cookieImage;
            Cookie.Stroke = null;

            // Инициализация текста
            UpdateCounters();
        }

        private void SetupEventHandlers()
        {
            Cookie.MouseDown += (sender, e) => {
                _gameLogic.ClickCookie();
                UpdateCounters();
            };

            GrandmaButton.MouseDown += (sender, e) => {
                _gameLogic.BuyGrandma();
                UpdateCounters();
            };
        }

        private void StartGame()
        {
            var timer = new DispatcherTimer(DispatcherPriority.Render)
            {
                Interval = new System.TimeSpan(0, 0, 0, 0, 1000)
            };

            timer.Tick += (sender, e) => {
                _gameLogic.Tick();
                UpdateCounters();
                UpdateGrandmaButtonState();
            };

            timer.Start();
        }

        private void UpdateCounters()
        {
            CookieCounterLabel.Content = _gameLogic.State.Cookies;
            GrandmaCounterLabel.Content = _gameLogic.State.Grandmas;
        }

        private void UpdateGrandmaButtonState()
        {
            GrandmaButton.IsEnabled = _gameLogic.CanBuyGrandma();
            GrandmaButton.Opacity = _gameLogic.CanBuyGrandma() ? 1 : 0.5;
        }
    }
}
