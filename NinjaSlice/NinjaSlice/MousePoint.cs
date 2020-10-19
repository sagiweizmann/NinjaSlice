using Microsoft.Xna.Framework;

namespace NinjaSlice
{
    internal class MousePoint
    {
        public Rectangle Size;
        public Vector2 Location;

        public MousePoint(Vector2 location, int size)//מיקום של העכבר וגודל שלו
        {
            this.Size = new Rectangle((int)location.X, (int)location.Y, size, size);
            this.Location = new Vector2(location.X, location.Y);
        }
    }
}
