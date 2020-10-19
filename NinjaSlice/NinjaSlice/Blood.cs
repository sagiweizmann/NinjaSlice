using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace DestroyTerror
{
    class Blood
    {
        Texture2D img;
        Vector2 pos;
        Color change;
        public Blood(Texture2D img, Vector2 pos)
        {
            this.img = img;
            this.pos = pos;
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(img, pos, change);
        }

    }
}
