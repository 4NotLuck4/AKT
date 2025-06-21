using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task2_Shooter
{
    public class Enemy
    {
        public Ellipse Shape { get; }
        private const int Size = 30;

        public Enemy(double canvasWidth)
        {
            Shape = new Ellipse
            {
                Width = Size,
                Height = Size,
                Fill = new SolidColorBrush(Colors.Purple)
            };

            var x = new Random().NextDouble() * (canvasWidth - Size);
            Canvas.SetLeft(Shape, x);
            Canvas.SetTop(Shape, -Size/2);
        }
    }
}
