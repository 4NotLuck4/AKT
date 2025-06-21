using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Task3_PingPong
{
    public class GameManager
    {
        private readonly Canvas _gameCanvas;
        private readonly Paddle _paddle;
        private readonly Ball _ball;
        private readonly DispatcherTimer _gameTimer;

        public GameManager(Canvas gameCanvas, Rectangle paddle, Ellipse ball)
        {
            _gameCanvas = gameCanvas;
            _paddle = new Paddle(paddle, gameCanvas.ActualWidth);
            _ball = new Ball(ball, gameCanvas.ActualWidth, gameCanvas.ActualHeight);

            _gameTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16) // ~60 FPS
            };
            _gameTimer.Tick += GameLoop;
        }

        public void StartGame()
        {
            _ball.ResetPosition();
            _gameTimer.Start();
        }

        public void HandleKeyPress(Key key)
        {
            const double paddleSpeed = 15;

            switch (key)
            {
                case Key.Left:
                    _paddle.Move(-paddleSpeed);
                    break;
                case Key.Right:
                    _paddle.Move(paddleSpeed);
                    break;
            }
        }

        private void GameLoop(object sender, EventArgs e)
        {
            _ball.Move();

            // Проверка столкновений с границами
            if (_ball.HitLeftWall() || _ball.HitRightWall(_gameCanvas.ActualWidth))
            {
                _ball.ReverseXDirection();
            }

            if (_ball.HitTopWall())
            {
                _ball.ReverseYDirection();
            }

            // Проверка столкновения с ракеткой
            if (_ball.HitPaddle(_paddle))
            {
                _ball.ReverseYDirection();
            }

            // Проверка проигрыша (мяч ушел за ракетку)
            if (_ball.BelowPaddle(_paddle, _gameCanvas.ActualHeight))
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            _gameTimer.Stop();
            MessageBox.Show("Game Over! Click OK to restart.");
            StartGame();
        }
    }
}
