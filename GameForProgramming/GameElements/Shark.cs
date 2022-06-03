using GameForProgramming.Engine;
using GameForProgramming.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameForProgramming.GameElements
{
    class Shark
    {
        public static Sprite2D sprite;
        public static Point position;
        public static Rectangle collideRectangle;
        private static int dirX;
        private static int dirY;
        private static bool LeftDirect = true;
        public static double sizeCoeff;
        private static Size startSize;
        
        public static void LoadShark()
        {
            sprite = new Sprite2D(new Point(500, 500), new Size(80, 31), Resources.Shark);
            position = sprite.position;
            startSize = sprite.size;
            collideRectangle = new Rectangle(sprite.position, sprite.size);
            sizeCoeff = 1;
            Form form = Form.ActiveForm;
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;
        }

        public static void OnUpdate()
        {
            Move();
            position = sprite.position;
            sprite.size.Width = Convert.ToInt32(startSize.Width * sizeCoeff);
            sprite.size.Height = Convert.ToInt32(startSize.Height * sizeCoeff);
            collideRectangle.Width = sprite.size.Width;
            collideRectangle.Height = sprite.size.Height;
        }
        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            dirX = 0;
            dirY = 0;
        }

        private  static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    dirX = -15;
                    if (!LeftDirect)
                    {
                        sprite.Sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                        LeftDirect = true;
                    }
                    break;
                case Keys.D:
                    dirX = 15;
                    if (LeftDirect)
                    {
                        sprite.Sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                        LeftDirect = false;
                    }
                    //sprite.Sprite.RotateFlip(RotateFlipType.Rotate180FlipX);
                    break;
                case Keys.W:
                    dirY = -15;
                    break;
                case Keys.S:
                    dirY = 15;
                    break;
            }
            
        }


        public static void Move()
        {
            if (!(sprite.position.X + sprite.size.Width + dirX > 1920 || sprite.position.X + dirX < 0))
            {
                sprite.position.X += dirX;
                collideRectangle.X += dirX;
            }
            if (sprite.position.X + sprite.size.Width + dirX > 1920)
            {
                sprite.position.X -= 20;
                collideRectangle.X -= 20;
            }
            if (sprite.position.X + dirX < 0)
            {
                sprite.position.X += 20;
                collideRectangle.X += 20;
            }

            if (!(sprite.position.Y + sprite.size.Height + dirY > 1080 || sprite.position.Y + dirY < 0))
            {
                sprite.position.Y += dirY;
                collideRectangle.Y += dirY;
            }
            if (sprite.position.Y + sprite.size.Height + dirY > 1080)
            {
                sprite.position.Y -= 20;
                collideRectangle.Y -= 20;
            }
            if (sprite.position.Y + dirY < 0)
            {
                sprite.position.Y += 20;
                collideRectangle.Y += 20;
            }

        }

        
    }
}
