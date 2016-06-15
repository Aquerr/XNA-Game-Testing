using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Game_Testing
{
    class gravity_jump
    {
        Texture2D texture;

        Vector2 position;
        Vector2 velocity;

        bool jumped;

        public int X { get; internal set; }
        public int Y { get; internal set; }

        public gravity_jump(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            jumped = true;
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

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && jumped == false)
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                jumped = true;
            }
            
            if (jumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }

            if (position.X + texture.Height >= 450)
                jumped = false;

            if (jumped == false)
                velocity.Y = 0f;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);            
        }


    }
}
