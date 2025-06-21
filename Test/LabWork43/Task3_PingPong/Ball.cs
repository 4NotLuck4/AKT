using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Task3_PingPong
{
    public class Ball
    {
        private readonly Ellipse _ball;
        private readonly double _canvasWidth;
        private readonly double _canvasHeight;

        private double _x;
        private double _y;
        private double _xSpeed;
        private double _ySpeed;
        private const double InitialSpeed = 5;

        public Ball(Ellipse ball, double canvasWidth, double canvasHeight)
        {
            _ball = ball;
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;

            ResetPosition();
        }

        public void ResetPosition()
        {
            _x = _canvasWidth / 2 - _ball.Width / 2;
            _y = _canvasHeight / 2 - _ball.Height / 2;

            var random = new Random();
            _xSpeed = random.NextDouble() > 0.5 ? InitialSpeed : -InitialSpeed;
            _ySpeed = InitialSpeed;

            UpdatePosition();
        }

        public void Move()
        {
            _x += _xSpeed;
            _y += _ySpeed;
            UpdatePosition();
        }

        public bool HitLeftWall() 
            => _x <= 0;

        public bool HitTopWall() 
            => _y <= 0;

        public bool HitRightWall(double canvasWidth) 
            => _x + _ball.Width >= canvasWidth;

        public bool BelowPaddle(Paddle paddle, double canvasHeight)
            => _y + _ball.Height >= canvasHeight;

        public bool HitPaddle(Paddle paddle)
        {
            var ballRect = new Rect(_x, _y, _ball.Width, _ball.Height);
            return ballRect.IntersectsWith(paddle.GetRect());
        }

        public void ReverseXDirection() 
            => _xSpeed = -_xSpeed;

        public void ReverseYDirection() 
            => _ySpeed = -_ySpeed;

        private void UpdatePosition()
        {
            Canvas.SetLeft(_ball, _x);
            Canvas.SetTop(_ball, _y);
        }
    }
}
