using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace NinjaSlice
{
    class Bomb
    {

        Texture2D sprite;
        Vector2 pos,orgin;
        Random rand = new Random();
        bool hit = false, end = false, Remove = false;
        float angle = 0;
        int x = 300, y = 2000;
                
        public Bomb(ContentManager Content)
        {
            sprite = Content.Load<Texture2D>("bomb");
            x = rand.Next(0, 600);
            pos = new Vector2(rand.Next(200,600), y);
        }
        public void Update(GameTime gameTime)
        {
            if (hit == false)
            {
                if (end == true)
                    y += 8;

                else
                    y -= 8;
                x += 1;
                pos = new Vector2(x, y);
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                angle += elapsed + (float)0.04;
                float circle = MathHelper.Pi * 2;
                angle = angle % circle;
            }
            else if (hit == true)
            {
                y += 10;
                pos = new Vector2(x, y);
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                angle += elapsed + (float)0.03;
                float circle = MathHelper.Pi * 2;
                angle = angle % circle;

            }

            if (y <= (rand.Next(0, 80)))
            {
                end = true;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, pos, null, Color.White, angle, orgin, 1f, SpriteEffects.None, 0);
        }
        public void Died()
        {
            hit = true;
        }
        public bool GetState()
        {
            return hit;
        }
        public Vector2 GetPos()
        {
            return pos;
        }
    }
}
