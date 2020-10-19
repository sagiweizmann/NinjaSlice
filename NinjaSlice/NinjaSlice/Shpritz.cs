using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;


namespace NinjaSlice
{
    class Shpritz
    {
        Texture2D img;
        Random rnd = new Random();
        Vector2 pos;
        int x;
        Color c = Color.White;
        public int alpha = 255;
        public Shpritz(ContentManager Content,Vector2 xy)
        {
            this.pos = xy;
            x=rnd.Next(0, 2);
            switch (x)
            {
                case 0:
                    img = Content.Load<Texture2D>("blood");
                    break;
                case 1:
                    img = Content.Load<Texture2D>("blood2");
                    break;
            } 


        }
        public void Draw(SpriteBatch sp)
        {
            sp.Draw(img, pos, c);
        }
        public void update()
        {
            //alpha-= 5;
            //c = new Color(255, 0, 0, alpha);
            c *= 0.99f;
            alpha = c.A;
        }
    }
}
