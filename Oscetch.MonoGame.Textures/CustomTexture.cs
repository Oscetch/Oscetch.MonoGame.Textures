using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Oscetch.MonoGame.Textures.Shapes;

namespace Oscetch.MonoGame.Textures
{
    public class CustomTexture : Texture2D
    {
        internal CustomTexture(GraphicsDevice graphicsDevice, Shape shape, bool isBordered = false)
               : base(graphicsDevice, shape.Size.X, shape.Size.Y)
        {
            var pixelColorFunc = isBordered ? shape.FunctionBordered() : shape.FunctionFilled();
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
