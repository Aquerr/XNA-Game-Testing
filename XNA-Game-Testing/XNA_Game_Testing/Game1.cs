using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Ridiculous
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Character player;

        List<Platform> platforms = new List<Platform>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Character(Content.Load<Texture2D>("playerIMG"), new Vector2(50, 100));

            platforms.Add(new Platform(Content.Load<Texture2D>("platformIMG"), new Vector2(30, 400)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platformIMG"), new Vector2(350, 300)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platformIMG"), new Vector2(600, 350)));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            IsMouseVisible = true;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Platform platform in platforms)
                if (player.rectangle.isOnTopOf(platform.rectangle))
                {
                    player.velocity.Y = 0f;
                    player.hasJumped = false;
                }
            player.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach (Platform platform in platforms)
            platform.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

static class RectangleHelper
{
    const int penetrationMargin = 5;
    public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Bottom >= r2.Top - penetrationMargin &&
            r1.Bottom <= r2.Top + 1 &&
            r1.Right >= r2.Left + 5 &&
            r1.Left <= r2.Right - 5);
    }
}