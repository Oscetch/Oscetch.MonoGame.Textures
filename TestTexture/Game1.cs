using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Oscetch.MonoGame.Textures;
using Oscetch.MonoGame.Textures.Enums;
using System.Collections.Generic;
using static Oscetch.MonoGame.Textures.CustomTextureParameters;

namespace TestTexture
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private readonly List<(Texture2D small, Texture2D larget)> _testGroups = new();
        private int _selectedIndex = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this) 
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight= 720
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            var fillColor = Color.White;
            var borderColor = Color.Violet;

            var smallTriangleParams = new CustomTextureParametersBuilder().WithSize(50).WithBorderThickness(5).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.Triangle).Build();
            var largeTriangleParams = new CustomTextureParametersBuilder().WithSize(300).WithBorderThickness(10).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.Triangle).Build();

            _testGroups.Add((CustomTextureManager.GetCustomTexture(smallTriangleParams, GraphicsDevice), CustomTextureManager.GetCustomTexture(largeTriangleParams, GraphicsDevice)));

            var smallRectangleRoundedParams = new CustomTextureParametersBuilder().WithSize(50).WithBorderThickness(5).WithFillColor(fillColor).WithBorderColor(borderColor).WithCornerRadius(10).WithShape(ShapeType.RectangleCornerRadius).Build();
            var largeRectangleRoundedParams = new CustomTextureParametersBuilder().WithSize(300).WithBorderThickness(10).WithFillColor(fillColor).WithBorderColor(borderColor).WithCornerRadius(20).WithShape(ShapeType.RectangleCornerRadius).Build();

            _testGroups.Add((CustomTextureManager.GetCustomTexture(smallRectangleRoundedParams, GraphicsDevice), CustomTextureManager.GetCustomTexture(largeRectangleRoundedParams, GraphicsDevice)));

            var smallCircleParams = new CustomTextureParametersBuilder().WithSize(50).WithBorderThickness(5).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.Circle).Build();
            var largeCircleParams = new CustomTextureParametersBuilder().WithSize(300).WithBorderThickness(10).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.Circle).Build();

            _testGroups.Add((CustomTextureManager.GetCustomTexture(smallCircleParams, GraphicsDevice), CustomTextureManager.GetCustomTexture(largeCircleParams, GraphicsDevice)));

            var smallCrossParams = new CustomTextureParametersBuilder().WithSize(50).WithBorderThickness(5).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.Cross).Build();
            var largeCrossParams = new CustomTextureParametersBuilder().WithSize(300).WithBorderThickness(10).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.Cross).Build();

            _testGroups.Add((CustomTextureManager.GetCustomTexture(smallCrossParams, GraphicsDevice), CustomTextureManager.GetCustomTexture(largeCrossParams, GraphicsDevice)));

            var smallRectangleParams = new CustomTextureParametersBuilder().WithSize(50).WithBorderThickness(5).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.Rectangle).Build();
            var largeRectangleParams = new CustomTextureParametersBuilder().WithSize(300).WithBorderThickness(10).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.Rectangle).Build();

            _testGroups.Add((CustomTextureManager.GetCustomTexture(smallRectangleParams, GraphicsDevice), CustomTextureManager.GetCustomTexture(largeRectangleParams, GraphicsDevice)));

            var smallRectangleWithCrossParams = new CustomTextureParametersBuilder().WithSize(50).WithBorderThickness(5).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.RectangleWithCross).Build();
            var largeRectangleWithCrossParams = new CustomTextureParametersBuilder().WithSize(300).WithBorderThickness(10).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.RectangleWithCross).Build();

            _testGroups.Add((CustomTextureManager.GetCustomTexture(smallRectangleWithCrossParams, GraphicsDevice), CustomTextureManager.GetCustomTexture(largeRectangleWithCrossParams, GraphicsDevice)));

            var smallXParams = new CustomTextureParametersBuilder().WithSize(50).WithBorderThickness(5).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.X).Build();
            var largeXParams = new CustomTextureParametersBuilder().WithSize(300).WithBorderThickness(10).WithFillColor(fillColor).WithBorderColor(borderColor).WithShape(ShapeType.X).Build();

            _testGroups.Add((CustomTextureManager.GetCustomTexture(smallXParams, GraphicsDevice), CustomTextureManager.GetCustomTexture(largeXParams, GraphicsDevice)));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        private KeyboardState _previousState;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_previousState.IsKeyDown(Keys.Enter) && Keyboard.GetState().IsKeyUp(Keys.Enter))
                _selectedIndex = (_selectedIndex + 1) % _testGroups.Count;

            _previousState = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var (small, large) = _testGroups[_selectedIndex];

            var screenCenter = new Vector2(1280, 720) / 2f;

            var verticalMargin = new Vector2(0, screenCenter.Y / 2);

            _spriteBatch.Begin();

            _spriteBatch.Draw(large, screenCenter - verticalMargin - (large.Bounds.Size.ToVector2() / 2f), Color.White);
            _spriteBatch.Draw(small, screenCenter + verticalMargin - (small.Bounds.Size.ToVector2() / 2f), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
