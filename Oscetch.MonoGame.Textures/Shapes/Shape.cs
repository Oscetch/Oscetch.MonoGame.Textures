using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oscetch.MonoGame.Textures.Shapes
{
    public abstract class Shape
    {
        public Point Size { get; protected set; }
        public Color BorderColor { get; protected set; }
        public Color FillColor { get; protected set; }

        public abstract Func<int, Color> FunctionBordered();

        public abstract Func<int, Color> FunctionFilled();


        protected int GetMaxXValue(IEnumerable<Point> points)
        {
            var maxX = int.MinValue;

            if (points == null || points.Count() == 0)
            {
                return maxX;
            }

            foreach (var point in points)
            {
                if (maxX > point.X)
                {
                    continue;
                }

                maxX = point.X;
            }

            return maxX;
        }

        protected int GetMinXValue(IEnumerable<Point> points)
        {
            var minX = int.MaxValue;

            if (points == null || points.Count() == 0)
            {
                return minX;
            }

            foreach (var point in points)
            {
                if (point.X > minX)
                {
                    continue;
                }

                minX = point.X;
            }

            return minX;
        }

        protected int GetMaxYValue(IEnumerable<Point> points)
        {
            var maxY = int.MinValue;

            if (points == null || points.Count() == 0)
            {
                return maxY;
            }

            foreach (var point in points)
            {
                if (maxY > point.Y)
                {
                    continue;
                }

                maxY = point.Y;
            }

            return maxY;
        }

        protected int GetMinYValue(IEnumerable<Point> points)
        {
            var minY = int.MaxValue;

            if (points == null || points.Count() == 0)
            {
                return minY;
            }

            foreach (var point in points)
            {
                if (point.Y > minY)
                {
                    continue;
                }

                minY = point.Y;
            }

            return minY;
        }
    }
}
