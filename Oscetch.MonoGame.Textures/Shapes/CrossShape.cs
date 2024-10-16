﻿using Microsoft.Xna.Framework;

namespace Oscetch.MonoGame.Textures.Shapes
{
    public class CrossShape : Shape
    {
        private readonly Point _center;
        private readonly (double min, double max) _xRange;
        private readonly (double min, double max) _yRange;

        private readonly Rectangle _innerRectangle;

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

            _innerRectangle = new Rectangle(crossThickness, crossThickness, size.X - crossThickness - crossThickness, size.Y - crossThickness - crossThickness);
        }

        private static bool IsInRange(int coordinate, (double min, double max) range)
        {
            return coordinate >= range.min && coordinate <= range.max;
        }

        public override Color Bordered(int index)
        {
            var yValue = (int)System.Math.Floor((double)index / Size.X);
            var xValue = index % Size.X;

            if (IsInRange(xValue, _xRange) || IsInRange(yValue, _yRange) || !_innerRectangle.Contains(new Point(xValue, yValue)))
            {
                return BorderColor;
            }
            else
            {
                return FillColor;
            }

        }

        public override Color Filled(int index)
        {
            var yValue = (int)System.Math.Floor((double)index / Size.X);
            var xValue = (index % Size.X) - 1;

            if (IsInRange(xValue, _xRange) || IsInRange(yValue, _yRange))
            {
                return BorderColor;
            }
            else
            {
                return FillColor;
            }
        }
    }
}
