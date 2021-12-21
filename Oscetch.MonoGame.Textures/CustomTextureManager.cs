using Microsoft.Xna.Framework.Graphics;
using Oscetch.MonoGame.Textures.Enums;
using Oscetch.MonoGame.Textures.Shapes;
using System.Collections.Generic;

namespace Oscetch.MonoGame.Textures
{
    public static class CustomTextureManager
    {
        private readonly static Dictionary<CustomTextureParameters, CustomTexture> _textureCache
            = new Dictionary<CustomTextureParameters, CustomTexture>();

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
            switch (parameters.ShapeType)
            {
                case ShapeType.Circle:
                    return new CircleShape(parameters.Size, parameters.FillColor, parameters.BorderColor);
                case ShapeType.Cross:
                    return new CrossShape(parameters.Size, parameters.BorderColor, parameters.FillColor, parameters.BorderThickness);
                case ShapeType.RectangleWithCross:
                    return new RectangleWithCrossShape(parameters.Size, parameters.BorderColor, parameters.FillColor, parameters.BorderThickness);
                case ShapeType.X:
                    return new XShape(parameters.Size, parameters.FillColor, parameters.BorderColor, parameters.BorderThickness);
                default:
                case ShapeType.Rectangle:
                    return new RectangleShape(parameters.Size, parameters.FillColor, parameters.BorderColor, parameters.BorderThickness);
            }
        }
    }
}
