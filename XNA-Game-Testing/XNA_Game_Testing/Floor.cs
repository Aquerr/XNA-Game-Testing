using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Game_Testing
{
    public class Floor : Game1
    {
       // GraphicsDeviceManager graphics;

        Rectangle _rectangle;
        public Vector2 _position;
        Texture2D floor_texture;

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
       {
           get { return _rectangle; }
           set
           {
               if(_rectangle != value)
               {
                   _rectangle = value;
               }
           }
       }

        public Floor(Texture2D newTexture, Vector2 newPosition)
        {
            _position = newPosition;
            floor_texture = newTexture;
            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, floor_texture.Width, floor_texture.Height);
            Rectangle = _rectangle;
            Position = _position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(floor_texture, _position, Color.White);
        }

       // public void RectangleIntersect(Rectangle something)
       // {
       //     if (_rectangle.Intersects(something))
       //     {
       //
       //     }
       // }

    }
}
