using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;


namespace NinjaSlice
{
    class Gun
    {
        Texture2D cursor;
        Vector2 pos;
        Rectangle rect;
        int x = 300, y = 1024;
        public Gun(ContentManager Content)
        {
            cursor = Content.Load<Texture2D>("cursorgreen");
        //    shot = Content.Load<SoundEffect>("Shot");
        }
        public void Update(GameTime gameTime,HamasSprite sp)
        {
            MouseState ms = Mouse.GetState();
            x=ms.X;
            bool clicked = false;
            y=ms.Y;
            pos = new Vector2(x, y);
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cursor, pos,Color.White);
        }

        public void MouseHover()
        {
           
        }
        public Vector2 GetPos()
        {
            return pos;
        }
    }
}
