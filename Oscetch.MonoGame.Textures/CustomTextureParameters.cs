using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Oscetch.MonoGame.Textures.Enums;

namespace Oscetch.MonoGame.Textures
{
    public class CustomTextureParameters
    {
        public ShapeType ShapeType { get; }
        public Point Size { get; }
        public Color BorderColor { get; }
        public Color FillColor { get; }
        public bool IsBordered { get; }
        public int BorderThickness { get; }
        public int CornerRadius { get; }

        private CustomTextureParameters(CustomTextureParametersBuilder builder) 
            : this(builder.ShapeType, builder.Size, builder.BorderColor, builder.FillColor, builder.IsBordered, builder.BorderThickness, builder.CornerRadius)
        {
        }

        [JsonConstructor]
        private CustomTextureParameters(ShapeType shapeType, Point size, Color borderColor, Color fillColor, bool isBordered, int borderThickness, int cornerRadius)
        {
            ShapeType = shapeType;
            Size = size;
            BorderColor = borderColor;
            FillColor = fillColor;
            BorderThickness = borderThickness;
            CornerRadius = cornerRadius;
            IsBordered = isBordered;
        }

        public override bool Equals(object obj)
        {
            return obj is CustomTextureParameters parameters &&
                   ShapeType == parameters.ShapeType &&
                   Size.Equals(parameters.Size) &&
                   BorderColor.Equals(parameters.BorderColor) &&
                   FillColor.Equals(parameters.FillColor) &&
                   IsBordered == parameters.IsBordered &&
                   BorderThickness == parameters.BorderThickness &&
                   CornerRadius == parameters.CornerRadius;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(ShapeType, Size, BorderColor, FillColor, IsBordered, BorderThickness, CornerRadius);
        }

        public class CustomTextureParametersBuilder
        {
            public ShapeType ShapeType { get; private set; } = ShapeType.Rectangle;
            public Point Size { get; private set; } = new Point(1);
            public Color BorderColor { get; private set; }
            public Color FillColor { get; private set; }
            public bool IsBordered { get; private set; } = false;
            public int BorderThickness { get; private set; } = 1;
            public int CornerRadius { get; private set;} = 0;

            public CustomTextureParametersBuilder WithSize(Point size)
            {
                Size = size;
                return this;
            }

            public CustomTextureParametersBuilder WithSize(Vector2 size)
            {
                return WithSize(size.ToPoint());
            }

            public CustomTextureParametersBuilder WithSize(int size)
            {
                return WithSize(new Point(size));
            }

            public CustomTextureParametersBuilder WithSize(int width, int height)
            {
                return WithSize(new Point(width, height));
            }
            public CustomTextureParametersBuilder WithSize(float width, float height)
            {
                return WithSize(new Vector2(width, height));
            }

            public CustomTextureParametersBuilder WithWidth(int width)
            {
                return WithSize(new Point(width, Size.Y));
            }

            public CustomTextureParametersBuilder WithWidth(float width)
            {
                return WithWidth((int)width);
            }

            public CustomTextureParametersBuilder WithHeight(int height)
            {
                return WithSize(new Point(Size.X, height));
            }

            public CustomTextureParametersBuilder WithHeight(float height)
            {
                return WithHeight((int)height);
            }

            public CustomTextureParametersBuilder HasBorder()
            {
                IsBordered = true;
                return this;
            }

            public CustomTextureParametersBuilder WithBorderThickness(int borderThickness)
            {
                BorderThickness = borderThickness;
                return HasBorder();
            }

            public CustomTextureParametersBuilder WithShape(ShapeType shapeType)
            {
                ShapeType = shapeType;
                return this;
            }

            public CustomTextureParametersBuilder WithBorderColor(Color borderColor)
            {
                BorderColor = borderColor;
                return HasBorder();
            }

            public CustomTextureParametersBuilder WithFillColor(Color fillColor)
            {
                FillColor = fillColor;
                return this;
            }

            public CustomTextureParametersBuilder WithCornerRadius(int cornerRadius)
            {
                CornerRadius = cornerRadius;
                return this;
            }

            public CustomTextureParameters Build()
            {
                return new CustomTextureParameters(this);
            }
        }
    }
}
