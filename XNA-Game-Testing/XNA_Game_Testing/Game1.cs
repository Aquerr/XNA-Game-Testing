using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNA_Game_Testing
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Texture2D player_texture;
        //Rectangle player;

        gravity_jump player;

        //Screen
        int screenWidth;
        int screenHeight;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
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

            //player_texture = Content.Load<Texture2D>("player");
            //player = new Rectangle(0, 0, player_texture.Width, player_texture.Height);
            player = new gravity_jump(Content.Load<Texture2D>("player"), new Vector2(50, 50));

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;


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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //    player.X += 6;
            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //    player.X -= 6;
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //    player.Y -= 6;
            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //    player.Y += 6;

            player.Update(gameTime);

            //granice okna
            //if (player.X <= 0)
            //    player.X = 0;

            //if (player.X + player_texture.Width >= screenWidth)
            //    player.X = screenWidth - player_texture.Width;

            //if (player.Y <= 0)
            //    player.Y = 0;

            //if (player.Y + player_texture.Height >= screenHeight)
            //    player.Y = screenHeight - player_texture.Height;



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
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
