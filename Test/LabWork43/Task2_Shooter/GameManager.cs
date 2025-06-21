using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Task2_Shooter
{
    public class GameManager
    {
        private readonly Canvas _gameCanvas;
        private readonly Label _scoreLabel;
        private readonly DispatcherTimer _spawnTimer;
        private readonly DispatcherTimer _movementTimer;
        private int _score;

        public GameManager(Canvas gameCanvas, Label scoreLabel)
        {
            _gameCanvas = gameCanvas;
            _scoreLabel = scoreLabel;

            _spawnTimer = new DispatcherTimer(DispatcherPriority.Render)
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            _spawnTimer.Tick += SpawnEnemy;

            _movementTimer = new DispatcherTimer(DispatcherPriority.Render)
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            _movementTimer.Tick += MoveEnemies;
        }

        public void StartGame()
        {
            _score = 0;
            _scoreLabel.Content = _score;
            _spawnTimer.Start();
            _movementTimer.Start();
        }

        private void SpawnEnemy(object sender, EventArgs e)
        {
            var enemy = new Enemy(_gameCanvas.ActualWidth);
            _gameCanvas.Children.Add(enemy.Shape);

            enemy.Shape.MouseDown += (s, args) =>
            {
                _gameCanvas.Children.Remove(enemy.Shape);
                _score++;
                _scoreLabel.Content = _score;
            };
        }

        private void MoveEnemies(object sender, EventArgs e)
        {
            foreach (var enemy in _gameCanvas.Children.OfType<Ellipse>())
            {
                double y = Canvas.GetTop(enemy);
                Canvas.SetTop(enemy, y + 3);

                if (y >= _gameCanvas.ActualHeight)
                {
                    GameOver();
                    return;
                }
            }
        }

        private void GameOver()
        {
            _spawnTimer.Stop();
            _movementTimer.Stop();
            MessageBox.Show($"Game Over! Your score: {_score}");
        }
    }
}
