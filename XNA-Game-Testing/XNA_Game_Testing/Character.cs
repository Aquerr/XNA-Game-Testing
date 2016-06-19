using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ridiculous
{
    class Character
    {
        Texture2D texture;
        Vector2 position;
        public Vector2 velocity;
        public bool hasJumped;
        public Rectangle rectangle;
        int jump=1;

        public Character(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            hasJumped = true;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                velocity.X = 3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                velocity.X = -3f;
            else
                velocity.X = 0f;
            // do zrobienia double jump
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                position.Y -= 1f;
                velocity.Y = -7f;
                hasJumped = true;
                jump++;
            }
            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }

            if (position.Y + texture.Height >= 475)
            {
                hasJumped = false;
            }
            if (jump == 3)
            {
                hasJumped = false;

            }

            if (hasJumped == false)
                velocity.Y = 0f;
        }
        public void Obstacle()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

    }
}
