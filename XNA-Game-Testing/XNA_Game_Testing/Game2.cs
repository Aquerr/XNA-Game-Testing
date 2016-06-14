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
using System.Threading;

namespace Skills
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game2 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //bool _freezeActive;
        
        //Game
        Texture2D ball_texture, deseczka_texture;
        Rectangle ball, deseczka, deseczka_opponent;
        Vector2 speed_ball;


        //Screen
        int screenWidth=1000;
        int screenHeight;

        //private void FreezeTest(object sender, EventArgs e)
        //{
           
        //}

        //private bool FreezeActive()
        //{
        //    if (_freezeActive == true) _freezeActive = false;
        //    else if (_freezeActive == false) _freezeActive = true;
        //    return _freezeActive;
        //}


        public Game2()
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
            //graphics.PreferredBackBufferWidth = 800; // okreœlamy tutaj szerokoœæ okna
            //graphics.PreferredBackBufferHeight = 640; // okreœlamy tutaj wysokoœæ okna

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

            ball_texture = Content.Load<Texture2D>("ball");
            ball = new Rectangle(300, 300, ball_texture.Width, ball_texture.Height);
            deseczka_texture = Content.Load<Texture2D>("deseczka");
            deseczka = new Rectangle(300, 420, deseczka_texture.Width, deseczka_texture.Height);
            deseczka_opponent = new Rectangle(300, 30, deseczka_texture.Width, deseczka_texture.Height);

            speed_ball.X = 8f;
            speed_ball.Y = 8f;

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

           
            
            // TODO: use this.Content to load your game content here
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //    ball.X += 6;
            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //    ball.X -= 6;
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //    ball.Y -= 6;
            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //    ball.Y += 6;

            //ruch platformy
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                deseczka.X += 6;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                deseczka.X -= 6;
            //deseczka.X = ball.X - (deseczka_texture.Width / 2);
            //granice platformy

            //kolizja
            if (ball.Intersects(deseczka))
                speed_ball.Y = -speed_ball.Y;
            //kolizja
            if (ball.Intersects(deseczka_opponent))
                speed_ball.Y = -speed_ball.Y;
            //ruch przeciwnika

            deseczka_opponent.X = ball.X - (deseczka_texture.Width / 2);

            //gameover
            if ((ball.Y >= ball_texture.Height + 420) || (ball.Y <= ball_texture.Height))
            {
                ball.X = 300;
                ball.Y = 300;
            }

            
            //ruch pilki

            if(Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                ball.X = ball.X + (int)speed_ball.X;
                ball.Y = ball.Y + (int)speed_ball.Y;
            }


            // if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    FreezeActive();
            //}

            
            //granice okna

            if (ball.X <= 0)
                ball.X = 0;
            if (ball.X + ball_texture.Width >= screenWidth)
                ball.X = screenWidth - ball_texture.Width;

            if (ball.Y <= 0)
                ball.Y = 0;
            if (ball.Y + ball_texture.Height >= screenHeight)
                ball.Y = screenHeight - ball_texture.Height;

            if (deseczka.X <= 0)
                deseczka.X = 0;
            if (deseczka.X + deseczka_texture.Width >= screenWidth)
                deseczka.X = screenWidth - deseczka_texture.Width;

            if (deseczka_opponent.X <= 0)
                deseczka_opponent.X = 0;
            if (deseczka_opponent.X + deseczka_texture.Width >= screenWidth)
                deseczka_opponent.X = screenWidth - deseczka_texture.Width;

            //Odbijanie od krawedzi

            if (ball.X <= 0)
                speed_ball.X = -speed_ball.X;
            if (ball.X + ball_texture.Width >= screenWidth)
                speed_ball.X = -speed_ball.X;

            if (ball.Y <= 0)
                speed_ball.Y = -speed_ball.Y;
            //if (ball.Y + ball_texture.Height >= screenHeight)
            //    speed_ball.Y = -speed_ball.Y;


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
            spriteBatch.Draw(ball_texture, ball, Color.White);
            spriteBatch.Draw(deseczka_texture, deseczka, Color.White);
            spriteBatch.Draw(deseczka_texture, deseczka_opponent, Color.White);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
