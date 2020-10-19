using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace NinjaSlice
{
    internal class Sword
    {
        private const int mouseSize = 20;
        private Texture2D circleText;
        private Texture2D aimText;
        private Vector2 circleDefaultSize;
        List<Shpritz> blood = new List<Shpritz>();
        private static List<MousePoint> mousePoints;
        private static List<MousePoint> allwaysPoints;
        private Vector2 lastMousePosition;
        public Vector2 bloodpos;
        SoundEffect s;
        Texture2D img;
        bool sd = false;
        public static List<MousePoint> MousePoints
        {
            get
            {
                return Sword.mousePoints;
            }
            set
            {
                Sword.mousePoints = value;
            }
        }

        public Sword(ContentManager Content)
        {
            this.circleText = Content.Load<Texture2D>("circle");
            this.aimText = Content.Load<Texture2D>("sword");
            Random rnd = new Random();
          
                    s = Content.Load<SoundEffect>("k1");
        
            this.circleDefaultSize = new Vector2((float)this.circleText.Width, (float)this.circleText.Height);
            Sword.allwaysPoints = new List<MousePoint>();
            Sword.mousePoints = new List<MousePoint>();
        }

        public void Update(GameTime gameTime,List<HamasSprite> members,ContentManager Content )
        {
           
            MouseState state = Mouse.GetState();
            bool clicked=false;
            if (state.LeftButton == ButtonState.Pressed)
            {
                this.reconcile_line(state, false);
                clicked=true;
            }
            this.lastMousePosition.X = (float)state.X;
            this.lastMousePosition.Y = (float)state.Y;
            foreach (HamasSprite item in members)
            {
                if (MouseHover(item) && clicked&&item.GetState()==false)
                {
                    item.Died();
                    blood.Add(new Shpritz(Content,item.GetPos()));
                    s.Play();
                    MainGame.scoreval += 1;
                }
            }
            for (int i = 0; i < blood.Count; i++)
            {
               blood[i].update();
               if (blood[i].alpha <= 5)
               {
                   blood.Remove(blood[i]);
                   i--;
               }
            }

            for (int index = 0; index < Sword.mousePoints.Count; ++index)
            {
                Sword.mousePoints[index].Size.Width -= 3;
                Sword.mousePoints[index].Size.Height -= 3;
                if (Sword.mousePoints[index].Size.Width <= 0 && Sword.mousePoints[index].Size.Height <= 0)
                {
                    Sword.mousePoints.RemoveAt(index);
                    --index;
                }
            }
        }
        public List<Shpritz> send()
        {
            return blood;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MousePoint mousePoint in Sword.mousePoints)
                spriteBatch.Draw(this.circleText, mousePoint.Size, new Rectangle?(), Color.White, 0.0f, new Vector2((float)mousePoint.Size.X, (float)mousePoint.Size.Y) / this.circleDefaultSize, (SpriteEffects)0, 0.0f);
            foreach (MousePoint mousePoint in Sword.allwaysPoints)
                spriteBatch.Draw(this.circleText, mousePoint.Size, new Rectangle?(), Color.Blue, 0.0f, new Vector2((float)mousePoint.Size.X, (float)mousePoint.Size.Y) / this.circleDefaultSize, (SpriteEffects)0, 0.0f);
            spriteBatch.Draw(this.aimText, this.lastMousePosition - new Vector2((float)this.aimText.Width, (float)this.aimText.Height) / 2f, Color.White);
 
        }

        public static void rstpoints()
        {
            Sword.allwaysPoints.Clear();
        }

        public static void addpoint(Vector2 l)
        {
            Sword.allwaysPoints.Add(new MousePoint(l, 6));
        }

        private void reconcile_line(MouseState ms, bool isSwitch)
        {
            Vector2 vector2_1 = new Vector2((float)ms.X, (float)ms.Y);//הקו שעוקב  אחרי העכבר
            Vector2 vector2_2 = vector2_1 - this.lastMousePosition;
            Vector2 vector2_3 = vector2_1 - this.lastMousePosition;
            vector2_3.Normalize();
            Vector2 location = this.lastMousePosition;
            int num1 = 0;
            int num2 = (int)((double)vector2_2.X / (double)vector2_3.X);
            if ((double)vector2_2.Y / (double)vector2_3.Y > (double)num2)
            {
                int num3 = (int)((double)vector2_2.Y / (double)vector2_3.Y);
            }
            do
            {
                Sword.mousePoints.Add(new MousePoint(location, 20));//מוסיף נקודה חדשה
                location += vector2_3;
                ++num1;
            }
            while ((double)vector2_3.Length() * (double)num1 <= (double)vector2_2.Length());
        }

        private List<Vector2> Line(Vector2 a, Vector2 b)/*מחזיר רשימה של הקו */
        {
            List<Vector2> list = new List<Vector2>();
            float num1 = (float)(((double)a.Y - (double)b.Y) / ((double)a.X - (double)b.X));
            float num2 = -1f * num1 * a.X + a.Y;
            int num3;
            int num4;
            if ((double)a.X > (double)b.X)
            {
                num3 = (int)b.X;
                num4 = (int)a.X;
            }
            else
            {
                num3 = (int)b.X;
                num4 = (int)a.X;
            }
            for (int index = num3; index <= num4; ++index)
                list.Add(new Vector2((float)index, num1 * (float)index + num2));
            return list;
        }
        private bool MouseHover(HamasSprite member)
        {
            Vector2 pos = member.GetPos();
            var dest = new Rectangle((int)pos.X, (int)pos.Y, 165, 165);
            bool mouseover = dest.Contains((int)lastMousePosition.X, (int)lastMousePosition.Y);
            return mouseover;
        }
        
    }
}
