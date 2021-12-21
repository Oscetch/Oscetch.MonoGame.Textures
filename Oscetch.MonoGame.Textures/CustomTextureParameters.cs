using Microsoft.Xna.Framework;
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

        private CustomTextureParameters(CustomTextureParametersBuilder builder)
        {
            Size = builder.Size;
            IsBordered = builder.IsBordered;
            BorderColor = builder.BorderColor;
            FillColor = builder.FillColor;
            BorderThickness = builder.BorderThickness;
            ShapeType = builder.ShapeType;
        }

        public override bool Equals(object obj)
        {
            return obj is CustomTextureParameters parameters &&
                   ShapeType == parameters.ShapeType &&
                   Size.Equals(parameters.Size) &&
                   BorderColor.Equals(parameters.BorderColor) &&
                   FillColor.Equals(parameters.FillColor) &&
                   IsBordered == parameters.IsBordered &&
                   BorderThickness == parameters.BorderThickness;
        }

        public override int GetHashCode()
        {
            int hashCode = 463341532;
            hashCode = hashCode * -1521134295 + ShapeType.GetHashCode();
            hashCode = hashCode * -1521134295 + Size.GetHashCode();
            hashCode = hashCode * -1521134295 + BorderColor.GetHashCode();
            hashCode = hashCode * -1521134295 + FillColor.GetHashCode();
            hashCode = hashCode * -1521134295 + IsBordered.GetHashCode();
            hashCode = hashCode * -1521134295 + BorderThickness.GetHashCode();
            return hashCode;
        }

        public class CustomTextureParametersBuilder
        {
            public ShapeType ShapeType { get; private set; } = ShapeType.Rectangle;
            public Point Size { get; private set; } = new Point(1);
            public Color BorderColor { get; private set; }
            public Color FillColor { get; private set; }
            public bool IsBordered { get; private set; } = false;
            public int BorderThickness { get; private set; } = 1;

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

            public CustomTextureParameters Build()
            {
                return new CustomTextureParameters(this);
            }
        }
    }
}
