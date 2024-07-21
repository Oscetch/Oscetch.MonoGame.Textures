using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Oscetch.MonoGame.Textures.Shapes;
using System;

namespace Oscetch.MonoGame.Textures
{
    public class CustomTexture : Texture2D
    {
        internal CustomTexture(GraphicsDevice graphicsDevice, Shape shape, bool isBordered = false)
               : base(graphicsDevice, shape.Size.X, shape.Size.Y)
        {
            Func<int, Color> pixelColorFunc = isBordered ? shape.Bordered : shape.Filled;
            var pixelColors = new Color[shape.Size.X * shape.Size.Y];

            for (int i = 0; i < pixelColors.Length; i++)
            {
                pixelColors[i] = pixelColorFunc(i);
            }

            SetData(pixelColors);
        }

        ~CustomTexture()
        {
            Dispose();
        }
    }
}
