using Microsoft.Xna.Framework;

namespace Oscetch.MonoGame.Textures.Shapes
{
    public class EllipseShape : Shape
    {
        public int BorderWidth { get; }

        public EllipseShape(Point size, Color fillColor = default, Color borderColor = default, int borderWidth = 0)
        {
            Size = size;
            BorderColor = borderColor;
            FillColor = fillColor;
            BorderWidth = borderWidth;
        }

        private static bool IsInside(Point pixel, Point center, Point axis)
        {
            var normalized = new Point(pixel.X - center.X, pixel.Y - center.Y);

            return (System.Math.Pow(normalized.X, 2) / System.Math.Pow(axis.X, 2) + System.Math.Pow(normalized.Y, 2) / System.Math.Pow(axis.Y, 2)) < 1;
        }

        public override Color Bordered(int index)
        {
            var halfSize = Size / new Point(2);
            var halfSizeBorder = (Size - new Point(BorderWidth * 2)) / new Point(2);
            var yValue = (int)System.Math.Floor((double)index / Size.X);
            var xValue = index % Size.X;

            var p = new Point(xValue, yValue);

            if (IsInside(p, halfSize, halfSize))
            {
                return IsInside(p, halfSize, halfSizeBorder) ? FillColor : BorderColor;
            }

            return Color.Transparent;
        }

        public override Color Filled(int index)
        {
            var halfSize = Size / new Point(2);
            var yValue = (int)System.Math.Floor((double)index / Size.X);
            var xValue = index % Size.X;

            var p = new Point(xValue, yValue);
            if (IsInside(p, halfSize, halfSize))
            {
                return FillColor;
            }

            return Color.Transparent;
        }
    }
}
