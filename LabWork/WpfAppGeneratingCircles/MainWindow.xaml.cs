using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfAppGeneratingCircles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random random = new();
        private readonly string[] tags = { "enemy", "hero", "treasure" };
        private readonly Color[] colors = { Colors.Red, Colors.Blue, Colors.Green, Colors.Yellow, Colors.Purple, Colors.Orange };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(MainCanvas);

            int size = random.Next(20, 70);
            Color color = colors[random.Next(colors.Length)];
            string tag = tags[random.Next(tags.Length)];

            Ellipse circle = new()
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(color),
                Tag = tag
            };

            Canvas.SetLeft(circle, position.X - size / 2);
            Canvas.SetTop(circle, position.Y - size / 2);

            circle.MouseDown += Circle_MouseDown;

            MainCanvas.Children.Add(circle);
        }

        private void Circle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Ellipse circle)
            {
                MessageBox.Show($"Clicked: {circle.Tag}");
                e.Handled = true; // Предотвращаем всплывание
            }
        }

    }
}