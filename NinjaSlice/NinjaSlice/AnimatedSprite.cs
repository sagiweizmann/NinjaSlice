using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NinjaSlice
{
    class AnimatedSprite
    {
        private int framecount; //frame amount
        private Texture2D[] Texture; //texture to draw
        private float TimePerFrame; //how much time show a frame
        private int Frame; //current position
        private float TotalElapsed; //time elapsed from last update

        public float Scale; //scale Image
        public Vector2 Origin; // position
        public SpriteEffects Effect; //effect is used to rotate

        public AnimatedSprite(SpriteEffects effect, Vector2 Origin, float Scale)
        {
            this.Origin = Origin;
            this.Scale = Scale;
            this.Effect = effect;
        }
        public void Load(ContentManager content, string[] asset, string Folder, int frameCount, int framesPerSec)
        {
            this.framecount = frameCount;
            this.Texture = new Texture2D[asset.Length];
            for (int i = 0; i < asset.Length; i++ )
            {
                this.Texture[i] = content.Load<Texture2D>(Folder + "/" + asset[i]); //asset is string name referance
            }
            //if (framesPerSec != -1)
                this.TimePerFrame = (float)1 / framesPerSec;
            //else
            //    this.TimePerFrame = 0;
            this.Frame = 0;
            this.TotalElapsed = 0;
        }
        public void updateFrame(float Elapsed)
        {
            if (this.TimePerFrame == -1)
                updateFrame();
            else
                updateFrameDelayed(Elapsed);
        }
        private void updateFrame()
        {
            //this is when I want to have no delay
            this.Frame++;
            this.Frame %= this.framecount;
        }
        private void updateFrameDelayed(float Elapsed)
        {
            //This is when I want to delay the frame rate
            this.TotalElapsed += Elapsed;
            if (this.TotalElapsed > this.TimePerFrame)
            {
                this.Frame++;
                this.Frame %= this.framecount; //keep it within total frame boundries
                this.TotalElapsed -= this.TimePerFrame;
            }
        }
        public void DrawFrame(SpriteBatch batch, Vector2 pos) //when not overriding inside Frame position
        {
            DrawFrame(batch, this.Frame, pos);
        }
        public void DrawFrame(SpriteBatch batch, int Frame, Vector2 pos) //When you want to override current frame
        {
            int frameWidth = this.Texture[this.Frame].Width;// this.framecount;
            Rectangle sourceRect = new Rectangle(0, 0, frameWidth, this.Texture[this.Frame].Height);
            Vector2 temp, temppos;
            /*if (this.Effect == SpriteEffects.FlipHorizontally)
            {
                temp = new Vector2(frameWidth, 0);
                temppos = new Vector2(pos.X + frameWidth, pos.Y);
            }
            else
            {*/
                temp = this.Origin;
                temppos = pos;
            //}   
            batch.Draw(this.Texture[this.Frame], temppos, sourceRect, Color.White, 0, temp, this.Scale, this.Effect, 0);
            //no need to rotate, only flip => therefore we use effects and not rotation
            //depth is also uneccessary
        }
        public int GetFrame()
        {
            return this.Frame;
        }
        public void Reset()
        {
            Frame = 0;
            TotalElapsed = 0f;
        }
    }
}
