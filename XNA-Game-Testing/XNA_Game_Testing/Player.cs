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

namespace XNA_Game_Testing
{
    class Player
    {
        Texture2D texture;
      //  Texture2D obstacle_texture;
        public Vector2 _position;
       // Vector2 position_texture;
        Vector2 velocity;
        Rectangle _rectangle;
        Floor _floor;

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set
            {
                if (_rectangle != value)
                {
                    _rectangle = value;
                }
            }
        }


        bool hasJumped;

        public Player(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            _position = newPosition;
            hasJumped = true;
            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, texture.Width, texture.Height);
            Rectangle = _rectangle;
            Position = _position;
            _floor = new Floor(Content.Load<Texture2D>("platform"));
        }
        
        public void Update(GameTime gameTime)
        {
            _position += velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                velocity.X = 4f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                velocity.X = -4f;
            else
                velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                _position.Y -= 50f;
                velocity.Y = -5f;
                hasJumped = true;
            }
            
            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }

            if (_position.Y + texture.Height >= 450)
                hasJumped = false;

            if (hasJumped == false)
                velocity.Y = 0f;
            if (_rectangle.Intersects(Floor.Rectangle)
            {
                _rectangle.Y =
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, _position, Color.White);            
        }

    }
}
