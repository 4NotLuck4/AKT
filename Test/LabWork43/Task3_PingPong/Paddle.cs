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
    public class Paddle
    {
        private readonly Rectangle _paddle;
        private readonly double _canvasWidth;

        public Paddle(Rectangle paddle, double canvasWidth)
        {
            _paddle = paddle;
            _canvasWidth = canvasWidth;

            // Установка начальной позиции
            Canvas.SetLeft(_paddle, (_canvasWidth - _paddle.Width) / 2);
        }

        public void Move(double offset)
        {
            var newLeft = Canvas.GetLeft(_paddle) + offset;

            // Проверка границ
            if (newLeft < 0)
                newLeft = 0;
            else if (newLeft + _paddle.Width > _canvasWidth)
                newLeft = _canvasWidth - _paddle.Width;

            Canvas.SetLeft(_paddle, newLeft);
        }

        public Rect GetRect()
        {
            return new Rect(
                Canvas.GetLeft(_paddle),
                Canvas.GetTop(_paddle),
                _paddle.Width,
                _paddle.Height);
        }
    }
}
