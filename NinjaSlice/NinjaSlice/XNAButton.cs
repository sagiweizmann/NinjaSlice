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

namespace NinjaSlice
{
    class XNAButton
    {
        Texture2D img, hover,back;
        Vector2 pos,msps;
        Game game;
        int state=0;
        int mode = 0;
        public XNAButton(Texture2D img, Vector2 pos,Texture2D hover,Game game)
        {
            this.img = img;
            this.back = img;
            this.pos = pos;
            this.hover = hover;
            this.game = game;
        }
        public void Update(int mode)
        {
            MouseState state = Mouse.GetState();
            this.msps.X = (float)state.X;
            this.msps.Y = (float)state.Y;
            bool clicked=false,checkhover=false;
            if (state.LeftButton == ButtonState.Pressed)
            {
                clicked = true;
            }
            this.mode = mode;

            if (MouseHover(state) == true)
            {
                back = img;
                img = hover;
               
            }
            else 
            {
                img = back;
            }
            if(clicked&&MouseHover(state))
            {
                BTNMode(game);
            }
        }
        public void Draw(SpriteBatch sp)
        {
            sp.Draw(img,pos,Color.White);
        }
        public int SendState()
        {
            return state;
        }
         private void OnHover()
        {
            this.img=hover;
        }

         private void BTNMode(Game game)
         {
            
             switch (this.mode)
             {
                 case 1:
                     game.Exit();
                 break;
                 case 2:
                 state = 1;
                 break;
                 case 3:

                 break;
             }
         }
         private bool MouseHover(MouseState state)
         {
            var dest = new Rectangle((int)pos.X, (int)pos.Y, 165, 165);
            bool mouseover;
            switch(this.mode)
            {
                case 1:
                 dest = new Rectangle((int)pos.X, (int)pos.Y, 177, 81);
                 mouseover = dest.Contains(state.X, state.Y);
                 break;
                case 2:
                 dest = new Rectangle((int)pos.X, (int)pos.Y, 200, 200);
                 mouseover = dest.Contains(state.X, state.Y);
                 break;
                case 3:
                 dest = new Rectangle((int)pos.X, (int)pos.Y, 165, 165);
                 mouseover = dest.Contains(state.X, state.Y);
                 break;
                default:
                 dest = new Rectangle((int)pos.X, (int)pos.Y, 165, 165);
                 mouseover = dest.Contains(state.X, state.Y);
                    break;
           }
             return mouseover;
         }
    }
}
