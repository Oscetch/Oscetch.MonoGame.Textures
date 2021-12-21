using Microsoft.Xna.Framework;
using Oscetch.MonoGame.Math.Objects;
using System;

namespace Oscetch.MonoGame.Textures.Shapes
{
    public class XShape : Shape
    {
        private readonly OscetchRectangle _topLeftBottomRight;
        private readonly OscetchRectangle _bottomLeftTopRight;

        public XShape(Point size, Color fillColor = default, Color borderColor = default, int lineWidth = 1)
        {
            Size = size;
            BorderColor = borderColor;
            FillColor = fillColor;

            var sizeVector = size.ToVector2();
            var width = Vector2.Distance(Vector2.Zero, sizeVector);
            var lineSize = new Vector2(width, lineWidth);

            _topLeftBottomRight = new OscetchRectangle(sizeVector / 2, lineSize,
                new Line(Vector2.Zero, sizeVector).GetAngleInRadians());
            _bottomLeftTopRight = new OscetchRectangle(sizeVector / 2, lineSize,
                new Line(new Vector2(0, size.Y), new Vector2(size.X, 0)).GetAngleInRadians());
        }

        public override Func<int, Color> FunctionBordered()
        {
            return x =>
            {
                var yValue = (int)System.Math.Floor((double)x / Size.X);
                var xValue = x % Size.X;
                var coord = new Vector2(xValue, yValue);

                if (_topLeftBottomRight.Contains(coord)
                    || _bottomLeftTopRight.Contains(coord))
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
            return FunctionBordered();
        }
    }
}
