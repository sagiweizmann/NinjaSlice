using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace NinjaSlice
{
    class HamasSprite
    {
       
        Random rand = new Random();
        Texture2D sprite,othersprite,transp;
        Vector2 pos,orgin;
        Rectangle rect;
        bool Dying = false,end=false,Remove=false;
        float angle=0;
        int mode;//Symbols the sprite mode menu/game
        int x = 300, y = 2000;
        int color;
        public HamasSprite(ContentManager Content,int mode)
        {

            x = rand.Next(0, 600);
            this.mode = mode;
            transp = Content.Load<Texture2D>("transp");
            color = rand.Next(0, 5);
            if (mode == 1)
            {
                color = 1;
            }
            if (mode == 2)
            {
                color = 0;
            }
            switch (color)
            {
                case 0:
                    sprite = Content.Load<Texture2D>("a2");
                    othersprite = Content.Load<Texture2D>("cutted");
                    break;
                case 1:
                    sprite = Content.Load<Texture2D>("yellow");
                    othersprite = Content.Load<Texture2D>("cuttedyel");
                    break;
                case 2:
                    sprite = Content.Load<Texture2D>("blue");
                    othersprite = Content.Load<Texture2D>("cuttedblue");
                    break;
                case 3:
                    sprite = Content.Load<Texture2D>("red");
                    othersprite = Content.Load<Texture2D>("cuttedred");
                    break;
                case 4:
                    sprite = Content.Load<Texture2D>("purple");
                    othersprite = Content.Load<Texture2D>("cuttedpur");
                    break;
            }

            pos = new Vector2(rand.Next(200,600), y);
        }
        public void Update(GameTime gameTime)
        {
            if (mode == 0)
            {
                if (Dying == false)
                {
                    if (end == true)
                        y += 8;

                    else
                        y -=12;
                    x +=1 ;
                    rect = new Rectangle((int)pos.X, (int)pos.Y, 165, 165);
                    pos = new Vector2(x, y);
                    float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    angle += elapsed + (float)0.06;
                    orgin = new Vector2(sprite.Width / 2, sprite.Height / 2);
                    float circle = MathHelper.Pi * 2;
                    angle = angle % circle;
                }
                else if (Dying == true)
                {

                    sprite = othersprite;
                    y += 10;
                    rect = new Rectangle((int)pos.X, (int)pos.Y, 165, 165);
                    pos = new Vector2(x, y);
                    float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    angle += elapsed + (float)0.03;
                   // orgin = new Vector2(sprite.Width / 2, sprite.Height / 2);
                    float circle = MathHelper.Pi * 2;
                    angle = angle % circle;

                }

                if (y <= (rand.Next(0, 80)))
                {
                    end = true;
                }
            }
            else if (mode == 1)
            {
                if (Dying == false)
                {
                    x = 280;
                    y = 500;
                    pos = new Vector2(x, y);
                    float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    angle += elapsed + (float)0.06;
                    orgin = new Vector2(sprite.Width / 2, sprite.Height / 2);
                    float circle = MathHelper.Pi * 2;
                    angle = angle % circle;
                }
                else if (Dying == true)
                {
                    sprite = othersprite;
                   // y += 10;
                    rect = new Rectangle((int)pos.X, (int)pos.Y, 165, 165);
                    pos = new Vector2(x, y);
                    float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    angle += elapsed + (float)0.06;
                    // orgin = new Vector2(sprite.Width / 2, sprite.Height / 2);
                    float circle = MathHelper.Pi * 2;
                    angle = angle % circle;
                    MainGame.startg = true;
                }
            }
            else if (mode == 2)
            {
                if (Dying == false)
                {
                    x = 760;
                    y = 500;
                    pos = new Vector2(x, y);
                    float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    angle += elapsed + (float)0.06;
                    orgin = new Vector2(sprite.Width / 2, sprite.Height / 2);
                    float circle = MathHelper.Pi * 2;
                    angle = angle % circle;
                }
                else if (Dying == true)
                {
                    sprite = othersprite;
                    // y += 10;
                    rect = new Rectangle((int)pos.X, (int)pos.Y, 165, 165);
                    pos = new Vector2(x, y);
                    float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    angle += elapsed + (float)0.06;
                    // orgin = new Vector2(sprite.Width / 2, sprite.Height / 2);
                    float circle = MathHelper.Pi * 2;
                    angle = angle % circle;
                    MainGame.startg = true;
                }
            }
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, pos,null,Color.White,angle,orgin,1f,SpriteEffects.None,0);
        }
        public bool Wait()
        {
            int a=0;
            while (a != 6000)
            {
                a++;
            }
            return true;
        }
        public void Died()
        {
            Dying = true;
        }
        public bool GetState()
        {
            return Dying;
        }
        public bool Removing()
        {
            if (y > 2001)
            {
                sprite = transp;
                Remove = true;
            }
            return Remove;
        }
        public Vector2 GetPos()
        {
            return pos;
        }
    }
}
