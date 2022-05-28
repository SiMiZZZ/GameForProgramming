using GameForProgramming.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForProgramming.GameElements
{
    public class NPCFish
    {
        public Sprite2D sprite;
        public Point position;
        public Size size;
        public Rectangle collideRectangle;
        public int speed = 2;
        private bool isWall = true;
        private int notWallCounter = 0;
        private bool rightDirection = true;

        public NPCFish(Point position, Size size, int speed, Bitmap texture)
        {
            sprite = new Sprite2D(position, size, texture);
            position = sprite.position;
            size = sprite.size;
            collideRectangle = new Rectangle(sprite.position, sprite.size);
            this.speed = speed;
        }

        public void OnUpdate()
        {
            if (position.X <= 0 || position.Y <= 0 || position.X + sprite.size.Width >= 1920 || position.Y + sprite.size.Height >= 1080)
            {
                speed *= -1;
                isWall = true;
            }
            if(isWall)
            {
                notWallCounter++;
                if (notWallCounter == 120)
                {
                    isWall = false;
                    speed *= -1;
                    notWallCounter = 0;
                }
            }
            var moveDirection = GetMoveDirection();

            if (moveDirection.X * speed >= 0 && rightDirection == false)
            {
                sprite.Sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                rightDirection = true;
            }
            if (moveDirection.X * speed < 0)
            {
                rightDirection = false;
            }

            sprite.position.X += moveDirection.X * speed;
            sprite.position.Y += moveDirection.Y * speed;
            
            position = sprite.position;
            
            collideRectangle.X = position.X;
            collideRectangle.Y = position.Y;
        }

        public Point GetMoveDirection()
        {
            if (position.X>= Shark.position.X && position.Y >= Shark.position.Y)
                return new Point(1, 1);
            if (position.X >= Shark.position.X && position.Y < Shark.position.Y)
                return new Point(1, -1);
            if (position.X < Shark.position.X && position.Y >= Shark.position.Y)
                return new Point(-1, 1);
            if (position.X < Shark.position.X && position.Y < Shark.position.Y)
                return new Point(-1, -1);
            return new Point(0, 0);
        }

    }
}
