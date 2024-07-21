using Microsoft.Xna.Framework;
using Oscetch.MonoGame.Math.Objects;
using Oscetch.MonoGame.Textures.Shapes;

namespace Oscetch.MonoGame.Textures.GL.Shapes
{
    internal class TriangleShape : Shape
    {
        public int BorderWidth { get; }

        private readonly OscetchPolygon _outerPolygon;
        private readonly OscetchPolygon _innerPolygon;

        public TriangleShape(Point size, Color fillColor = default, Color borderColor = default, int borderWidth = 1)
        {
            Size = size;
            BorderColor = borderColor;
            FillColor = fillColor;
            BorderWidth = borderWidth;

            _outerPolygon = new OscetchPolygon(
                0,
                Vector2.Zero,
                new Vector2(0, size.Y),
                new Vector2(size.X / 2f, 0),
                new Vector2(size.X, size.Y)
            );
            _innerPolygon = new OscetchPolygon(
                0,
                Vector2.Zero,
                new Vector2(borderWidth, size.Y - (borderWidth / 2)),
                new Vector2(size.X / 2f, borderWidth),
                new Vector2(size.X - borderWidth, size.Y - (borderWidth / 2))
            );
        }

        public override Color Bordered(int index)
        {
            var yValue = (int)System.Math.Floor((double)index / Size.X);
            var xValue = index % Size.X;
            var p = new Vector2(xValue, yValue);

            if (_innerPolygon.Contains(p))
            {
                return FillColor;
            }
            if (_outerPolygon.Contains(p))
            {
                return BorderColor;
            }
            return Color.Transparent;
        }

        public override Color Filled(int index)
        {
            var yValue = (int)System.Math.Floor((double)index / Size.X);
            var xValue = index % Size.X;
            return _outerPolygon.Contains(new Vector2(xValue, yValue))
                ? FillColor : Color.Transparent;
        }
    }
}
