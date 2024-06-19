using Microsoft.Xna.Framework;
using System;

namespace Oscetch.MonoGame.Textures.Shapes
{
    public class RectangleWithCrossShape : Shape
    {
        private readonly Point _center;
        private readonly (double min, double max) _xRange;
        private readonly (double min, double max) _yRange;

        public int BorderThickness { get; }

        public RectangleWithCrossShape(Point size, Color borderColor, Color fillColor = default, int borderThickness = 1)
        {
            Size = size;
            BorderColor = borderColor;
            FillColor = fillColor;
            BorderThickness = borderThickness;
            _center = size / new Point(2);
            var crossRange = borderThickness / 2d;
            _xRange = (_center.X - crossRange, _center.X + crossRange);
            _yRange = (_center.Y - crossRange, _center.Y + crossRange);
        }
        private static bool IsInRange(int coordinate, (double min, double max) range)
        {
            return coordinate >= range.min && coordinate <= range.max;
        }

        public override Func<int, Color> FunctionBordered()
        {
            if (BorderThickness == 0)
            {
                return FunctionFilled();
            }
            return x =>
            {
                var yValue = (int)System.Math.Floor((double)x / Size.X);
                var xValue = x % Size.X;

                if (xValue >= 0 && xValue <= BorderThickness || xValue <= Size.X && xValue >= Size.X - BorderThickness ||
                    yValue >= 0 && yValue <= BorderThickness || yValue <= Size.Y && yValue >= Size.Y - BorderThickness ||
                    IsInRange(xValue, _xRange) || IsInRange(yValue, _yRange) ||
                    xValue == 0 || xValue == Size.X - 1 || yValue == 0 || yValue == Size.Y - 1)
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
            return x =>
            {
                var yValue = (int)System.Math.Floor((double)x / Size.X);
                var xValue = x % Size.X;

                if (IsInRange(xValue, _xRange) || IsInRange(yValue, _yRange) ||
                    xValue == 0 || xValue == Size.X - 1 || yValue == 0 || yValue == Size.Y - 1)
                {
                    return BorderColor;
                }
                else
                {
                    return FillColor;
                }
            };
        }
    }
}
