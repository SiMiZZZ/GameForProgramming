using GameForProgramming.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameForProgramming.Properties;
using System.Windows.Forms;

namespace GameForProgramming.Scenes
{
    public class MainScene : Scene
    {
        Sprite2D BackGround = new Sprite2D(new Point(0, 0), new Size(1920, 1080), Resources.BackgroundSea);
        Sprite2D Fish = new Sprite2D(new Point(100, 100), new Size(300, 300), Resources.YellowFish);
        Button NewGameButton = Core.CreateButton(600, 200, 690, 400, "", Resources.newGameButton);
        Button StopButton = Core.CreateButton(300, 150, 840, 650, "", Resources.StopButton);

        public MainScene(string tag) : base(tag) { }
        
        public override void OnLoad()
        {
            RegisterObject(BackGround);
            RegisterObject(Fish);
            RegisterObject(NewGameButton);
            RegisterObject(StopButton);
            NewGameButton.Click += NewGameButton_Click;
            StopButton.Click += StopButton_Click;
        }

        public override void OnUpdate()
        {
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Fish.position.X += 30;
            Game.GetScene("GameScene");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
