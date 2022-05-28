using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForProgramming.Engine
{
    public class Sprite2D 
    {
        public Point position;
        public Size size;
        public Bitmap Sprite = null;

        public Sprite2D(Point position, Size size, Bitmap Sprite)
        {
            this.position = new Point(position.X, position.Y);
            this.size = new Size(size.Width, size.Height);
            this.Sprite = Sprite;
        }
    }
}
