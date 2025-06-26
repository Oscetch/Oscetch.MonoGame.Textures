using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Oscetch.MonoGame.Textures.Shapes
{
    internal class RoundedCornerRectangle : Shape
    {
        public int BorderWidth { get; }
        public int CornerRadius { get; }

        private readonly List<Rectangle> _outerRectangles;
        private readonly List<Rectangle> _innerRectangles;
        private readonly List<Vector2> _outerCircleCenters;
        private readonly int _innerRadius;

        public RoundedCornerRectangle(Point size, int cornerRadius = 10, Color fillColor = default, Color borderColor = default, int borderWidth = 1)
        {
            Size = size;
            BorderColor = borderColor;
            FillColor = fillColor;
            BorderWidth = borderWidth;
            CornerRadius = System.Math.Max(1, cornerRadius);
            _outerRectangles =
            [
                new (0, CornerRadius, Size.X, Size.Y - (CornerRadius * 2)), // horizontal
                new (CornerRadius, 0, Size.X - (CornerRadius * 2), Size.Y), // vertical
            ];
            _innerRectangles =
            [
                new (CornerRadius, BorderWidth, Size.X - (CornerRadius + CornerRadius), Size.Y - BorderWidth - BorderWidth),
                new (BorderWidth, CornerRadius, Size.X - BorderWidth - BorderWidth, Size.Y - CornerRadius - CornerRadius),
            ];
            _outerCircleCenters =
            [
                new (CornerRadius, CornerRadius), // top left
                new (CornerRadius, Size.Y - CornerRadius), // bottom left
                new (Size.X - CornerRadius, CornerRadius), // top right
                new (Size.X - CornerRadius, Size.Y - CornerRadius) // bottom right
            ];
            _innerRadius = CornerRadius - BorderWidth;
        }

        public override Color Bordered(int index)
        {
            if (BorderWidth == 0)
            {
                return Filled(index);
            }

            var yValue = (int)System.Math.Floor((double)index / Size.X);
            var xValue = index % Size.X;
            var p = new Point(xValue, yValue);
            var v = p.ToVector2();

            var overlapsRectangles = _outerRectangles.Any(x => x.Contains(p));
            var closest = _outerCircleCenters.Min(x => Vector2.Distance(x, v));
            var overlapsCircles = closest <= CornerRadius;

            if (overlapsRectangles && overlapsCircles)
            {
                if (closest <= _innerRadius || _innerRectangles.Any(x => x.Contains(p)))
                {
                    return FillColor;
                }
                return BorderColor;
            }

            if (overlapsRectangles)
            {
                if (_innerRectangles.Any(x => x.Contains(p)))
                {
                    return FillColor;
                }
                return BorderColor;
            }

            if (closest <= CornerRadius)
            {
                return closest <= _innerRadius ? FillColor : BorderColor;
            }

            return Color.Transparent;
        }

        public override Color Filled(int index)
        {
            var yValue = (int)System.Math.Floor((double)index / Size.X);
            var xValue = index % Size.X;

            var p = new Point(xValue, yValue);
            if (_outerRectangles.Any(x => x.Contains(p)))
            {
                return FillColor;
            }
            var v = p.ToVector2();

            if (_outerCircleCenters.Any(x => Vector2.Distance(x, v) <= CornerRadius))
            {
                return FillColor;
            }

            return Color.Transparent;
        }
    }
}
