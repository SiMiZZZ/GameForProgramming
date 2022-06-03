using GameForProgramming.Engine;
using GameForProgramming.GameElements;
using GameForProgramming.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameForProgramming.Scenes
{
    public class GameScene : Scene
    {
        static Random rnd = new Random();

        //static NPCFish Fish1 = new NPCFish(new Point(700, 50), new Size(50, 50), Resources.YellowFish);
        //static NPCFish Fish2 = new NPCFish(new Point(100, 400), new Size(50, 50), Resources.YellowFish);
        //static NPCFish Fish3 = new NPCFish(new Point(300, 600), new Size(50, 50), Resources.YellowFish);
        static int Score = 0;
        static Sprite2D BackGround = new Sprite2D(new Point(0, 0), new Size(1920, 1080), Resources.GameBackground);
        static Sprite2D ScorePanel = new Sprite2D(new Point(0, 0), new Size(340, 165), Resources.ScorePanel);
        static Label ScoreLabel = Core.CreateLabel(140, 50, 40, 60, "Score:");
        static Label ScoreResultLabel = Core.CreateLabel(100, 50, 180, 65, Score.ToString());
        Button ShopButton = Core.CreateButton(200, 100, 1700, 0, "", Resources.ShopButton);



        public static List<NPCFish> Fishes = new List<NPCFish>();
        static int count = 0;
        static int killedFish = 0;
        static int speedOfNewFish = 1;
        public GameScene(string tag) : base(tag) { }

        public override void OnLoad()
        {
            Shark.LoadShark();
            RegisterObject(BackGround);
            RegisterObject(Shark.sprite);
            RegisterObject(ScorePanel);
            RegisterObject(ScoreLabel);
            RegisterObject(ScoreResultLabel);
            RegisterObject(ShopButton);
            ShopButton.Click += (object sender, EventArgs e) => Score++;
            CreateFishes(10);
        }

        public override void OnUpdate()
        {
            Eating();
            if (Fishes.Count < 3)
                CreateFishes(3);
            UpgradeFish();
            ScoreResultLabel.Text = Score.ToString();
        }

        public void Eating()
        {
            var removeList = new List<NPCFish>();
            foreach (var fish in Fishes)
            {
                if (Shark.collideRectangle.IntersectsWith(fish.collideRectangle))
                {
                    UnRegisterObject(fish);
                    removeList.Add(fish);
                    if (Shark.sizeCoeff<3.5)
                        Shark.sizeCoeff += 0.3;
                    count--;
                    killedFish++;
                    Score += 10;
                }
                
            }
            foreach (var a in removeList)
            Fishes.Remove(a);
        }

        public void CreateFishes(int quanity)
        {
            for (var i = 0; i<quanity; i++)
            {
                var sizeNum = rnd.Next(50, 150);
                var newFish = new NPCFish(new Point(rnd.Next(0, 1600), rnd.Next(0, 900)), new Size(sizeNum, sizeNum), speedOfNewFish, Resources.YellowFish);
                Fishes.Add(newFish);
                RegisterObject(newFish);
                count++;
            }
        }
        

        public void UpgradeFish()
        {
            switch(killedFish)
            {
                case 5:
                    speedOfNewFish = 2;
                    break;
                case 10:
                    speedOfNewFish = 3;
                    break;
                case 15:
                    speedOfNewFish = 4;
                    break;
                case 20:
                    speedOfNewFish = 5;
                    break;
                case 25:
                    speedOfNewFish = 6;
                    break;


            }
            if (killedFish == 7)
            {
                foreach (var fish in Fishes)
                {
                    fish.speed = 5;
                    speedOfNewFish = 5;
                }
            }
        }
    }
}
