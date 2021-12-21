using Microsoft.Xna.Framework;
using System;

namespace Oscetch.MonoGame.Textures.Shapes
{
    public class RectangleShape : Shape
    {
        public int BorderWidth { get; }

        public RectangleShape(Point size, Color fillColor = default, Color borderColor = default, int borderWidth = 1)
        {
            Size = size;
            BorderColor = borderColor;
            FillColor = fillColor;
            BorderWidth = borderWidth;
        }

        public RectangleShape(int width, int height, Color fillColor = default, Color borderColor = default, int borderWidth = 1)
            : this(new Point(width, height), fillColor, borderColor, borderWidth) { }

        public override Func<int, Color> FunctionBordered()
        {
            if (BorderWidth == 0)
            {
                return FunctionFilled();
            }
            return x =>
            {
                var yValue = (int)System.Math.Floor((double)x / Size.X);
                var xValue = x % Size.X;

                if (xValue >= 0 && xValue <= BorderWidth || xValue <= Size.X && xValue >= Size.X - BorderWidth ||
                    yValue >= 0 && yValue <= BorderWidth || yValue <= Size.Y && yValue >= Size.Y - BorderWidth)
                {
                    return BorderColor;
                }
                else
                {
                    return FillColor;
                }
            };
        }

        public override Func<int, Color> FunctionFilled()
        {
            return x => FillColor;
        }
    }
}
