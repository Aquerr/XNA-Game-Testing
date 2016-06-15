using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Game_Testing
{
    class Player
    {
        Texture2D texture;
        Texture2D obstacle_texture;
        Vector2 position;
        Vector2 position_texture;
        Vector2 velocity;
        Rectangle recta

        bool hasJumped;

        
        public Player(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            hasJumped = true;
        }
        public void Obstacle(Texture2D newTexture, Vector2 newPosition)
        {
            obstacle_texture = newTexture;
            position_texture = newPosition;
            if(texture.Intersects)
        }
        public void Update(GameTime gameTime)
        {
            position += velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                velocity.X = 3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                velocity.X = -3f;
            else
                velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                hasJumped = true;
            }
            
            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }

            if (position.Y + texture.Height >= 450)
                hasJumped = false;

            if (hasJumped == false)
                velocity.Y = 0f;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);            
        }

    }
}
