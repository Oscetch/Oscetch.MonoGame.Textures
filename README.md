# Oscetch.MonoGame.Textures

A library for generating monogame textures

## Usage

The library can generate these shapes:

- Circle/Ellipse
- Cross
- Rectangle
- Rectangle with a corner radius
- Rectangle with a cross in the middle
- X shape
- Triangle
- Dialog box, which is just a rounded corner rectangle, without any radius on the bottom left

To generate a texture you create a builder, set the parameters and build:

```csharp
var textureParams = new CustomTextureParametersBuilder()
  .WithSize(300)
  .WithBorderThickness(10)
  .WithFillColor(Color.White)
  .WithBorderColor(Color.Violet)
  .WithCornerRadius(20)
  .WithShape(ShapeType.RectangleCornerRadius)
  .Build();
```

Then use the `CustomTextureManager` to get the texture:

```csharp
var texture = CustomTextureManager.GetCustomTexture(textureParams, GraphicsDevice);
```

The `CustomTextureManager` will cache the texture with the parameters you gave it. So the same texture will be reused if you try to build the same texture multiple times.
To clear this cache you call:

```csharp
CustomTextureManager.ClearCache();
```
