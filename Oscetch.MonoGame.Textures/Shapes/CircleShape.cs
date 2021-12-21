using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oscetch.MonoGame.Textures.Shapes
{
    public class CircleShape : Shape
    {
        public CircleShape(Point size, Color fillColor = default, Color borderColor = default)
        {
            Size = size;
            BorderColor = borderColor;
            FillColor = fillColor;
        }

        public override Func<int, Color> FunctionBordered()
        {
            var acceptableValues = new List<Point>();
            for (var angle = 0; angle < 360; angle++)
            {
                var angleRadians = MathHelper.ToRadians(angle);
                var x = (int)(Size.X * System.Math.Cos(angleRadians));
                var y = (int)(Size.Y * System.Math.Sin(angleRadians));
                acceptableValues.Add(new Point(x, y));
            }
            return x =>
            {
                var yValue = (int)System.Math.Floor((double)x / Size.X);
                var xValue = x % Size.X;
                if (acceptableValues.Contains(new Point(xValue, yValue)))
                {
                    return BorderColor;
                }

                var potentialXValues = acceptableValues.Where(val => val.Y == yValue);
                var potentialYValues = acceptableValues.Where(val => val.X == xValue);

                var maxY = GetMaxYValue(potentialYValues);
                var minY = GetMinYValue(potentialYValues);
                var maxX = GetMaxXValue(potentialXValues);
                var minX = GetMinXValue(potentialXValues);

                if (xValue > minX && xValue < maxX && yValue > minY && yValue < maxY)
                {
                    return FillColor;
                }
                else
                {
                    return Color.Transparent;
                }
            };
        }

        public override Func<int, Color> FunctionFilled()
        {
            var xCenter = Size.X / 2;
            var yCenter = Size.Y / 2;
            var acceptableValues = new List<Point>();
            for (var angle = 0; angle < 360; angle++)
            {
                var x = (int)(xCenter + xCenter * System.Math.Cos(angle * System.Math.PI / 180));
                var y = (int)(yCenter + yCenter * System.Math.Sin(angle * System.Math.PI / 180));
                acceptableValues.Add(new Point(x, y));
            }
            return x =>
            {
                var yValue = (int)System.Math.Floor((double)x / Size.X);
                var xValue = x % Size.X;
                if (acceptableValues.Contains(new Point(xValue, yValue)))
                {
                    return FillColor;
                }

                var potentialXValues = acceptableValues.Where(val => val.Y == yValue);
                var potentialYValues = acceptableValues.Where(val => val.X == xValue);

                var maxY = GetMaxYValue(potentialYValues);
                var minY = GetMinYValue(potentialYValues);
                var maxX = GetMaxXValue(potentialXValues);
                var minX = GetMinXValue(potentialXValues);

                if (xValue > minX && xValue < maxX && yValue > minY && yValue < maxY)
                {
                    return FillColor;
                }
                else
                {
                    return Color.Transparent;
                }
            };
        }
    }
}
