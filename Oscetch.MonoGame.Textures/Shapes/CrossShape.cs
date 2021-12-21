using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oscetch.MonoGame.Textures.Shapes
{
    public class CrossShape : Shape
    {
        private readonly Point _center;
        private readonly (double min, double max) _xRange;
        private readonly (double min, double max) _yRange;

        public int CrossThickness { get; }

        public CrossShape(Point size, Color crossColor, Color fillColor = default, int crossThickness = 1)
        {
            _center = size / new Point(2);
            var crossRange = crossThickness / 2d;
            _xRange = (_center.X - crossRange, _center.X + crossRange);
            _yRange = (_center.Y - crossRange, _center.Y + crossRange);

            Size = size;
            BorderColor = crossColor;
            FillColor = fillColor;
            CrossThickness = crossThickness;
        }

        private bool IsInRange(int coordinate, (double min, double max) range)
        {
            return coordinate >= range.min && coordinate <= range.max;
        }

        public override Func<int, Color> FunctionBordered()
        {
            return x =>
            {
                var yValue = ((int)System.Math.Floor((double)x / Size.X));
                var xValue = (x % Size.X);

                if (IsInRange(xValue, _xRange) || IsInRange(yValue, _yRange)
                    || xValue == 0 || xValue == Size.X - 1 || yValue == 0 || yValue == Size.Y - 1)
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
                var xValue = (x % Size.X) - 1;

                if (IsInRange(xValue, _xRange) || IsInRange(yValue, _yRange))
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
