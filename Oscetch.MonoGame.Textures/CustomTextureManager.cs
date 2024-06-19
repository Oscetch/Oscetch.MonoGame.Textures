using Microsoft.Xna.Framework.Graphics;
using Oscetch.MonoGame.Textures.Enums;
using Oscetch.MonoGame.Textures.Shapes;
using System.Collections.Generic;

namespace Oscetch.MonoGame.Textures
{
    public static class CustomTextureManager
    {
        private readonly static Dictionary<CustomTextureParameters, CustomTexture> _textureCache
            = new();

        public static CustomTexture GetCustomTexture(CustomTextureParameters parameters, GraphicsDevice graphicsDevice)
        {
            if (_textureCache.TryGetValue(parameters, out var cachedTexture)
                && !cachedTexture.IsDisposed)
            {
                return cachedTexture;
            }

            var shape = GetShape(parameters);
            var newTexture = new CustomTexture(graphicsDevice, shape, parameters.IsBordered);
            _textureCache[parameters] = newTexture;
            return newTexture;
        }

        public static bool TryGetTextureFromCache(CustomTextureParameters parameters, out CustomTexture texture)
        {
            return _textureCache.TryGetValue(parameters, out texture);
        }

        public static void ClearCache()
        {
            foreach (var texture in _textureCache.Values)
            {
                texture.Dispose();
            }

            _textureCache.Clear();
        }

        private static Shape GetShape(CustomTextureParameters parameters)
        {
            return parameters.ShapeType switch
            {
                ShapeType.Circle => new EllipseShape(parameters.Size, parameters.FillColor, parameters.BorderColor, parameters.BorderThickness),
                ShapeType.Cross => new CrossShape(parameters.Size, parameters.BorderColor, parameters.FillColor, parameters.BorderThickness),
                ShapeType.RectangleWithCross => new RectangleWithCrossShape(parameters.Size, parameters.BorderColor, parameters.FillColor, parameters.BorderThickness),
                ShapeType.X => new XShape(parameters.Size, parameters.FillColor, parameters.BorderColor, parameters.BorderThickness),
                ShapeType.RectangleCornerRadius => new RoundedCornerRectangle(parameters.Size, parameters.CornerRadius, parameters.BorderColor, parameters.FillColor, parameters.BorderThickness),
                _ => new RectangleShape(parameters.Size, parameters.FillColor, parameters.BorderColor, parameters.BorderThickness),
            };
        }
    }
}
