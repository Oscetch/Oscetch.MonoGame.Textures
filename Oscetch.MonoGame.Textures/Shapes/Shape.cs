using Microsoft.Xna.Framework;
using System;

namespace Oscetch.MonoGame.Textures.Shapes
{
    public abstract class Shape
    {
        public Point Size { get; protected set; }
        public Color BorderColor { get; protected set; }
        public Color FillColor { get; protected set; }

        public abstract Func<int, Color> FunctionBordered();

        public abstract Func<int, Color> FunctionFilled();
    }
}
