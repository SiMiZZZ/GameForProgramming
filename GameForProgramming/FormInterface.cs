using GameForProgramming.Engine;
using GameForProgramming.GameElements;
using GameForProgramming.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameForProgramming
{
    class FormInterface : Form
    {
        
        public FormInterface()
        {
            ClientSize = new Size(1920, 1080);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Game";
            Text = "StudentGame";
            TopMost = true;
            //WindowState = FormWindowState.Maximized;          
        }
    }

    class Game
    {
        public static  Timer timer = new Timer();
        public static FormInterface Window;

        public static MainScene Menu = new MainScene("MainScene");
        public static GameScene MainGame = new GameScene("GameScene");


        public static int CurrentSceneID = 0;
        public Game()
        {
            Window = new FormInterface();
            
            Window.Load += GameLoad;
            Window.Paint += RendererTextures;
            Application.Run(Window);

        }

        private void GameLoad(object sender, EventArgs e)
        {
            timer.Interval = 10;
            timer.Tick += new EventHandler(Update);
            timer.Start();
            Menu.OnLoad();
            MainGame.OnLoad();
        }

        public void Update(object sender, EventArgs e)
        {
            RenderedInterface();
            Menu.OnUpdate();
            MainGame.OnUpdate();
            Shark.OnUpdate();
            UpdateGameElements();
            Window.Invalidate();
        }
        

        private static void RendererTextures(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var sprite in Core.Scenes[CurrentSceneID].AllSprites)
                g.DrawImage(sprite.Sprite, new Rectangle(
                       new Point(sprite.position.X, sprite.position.Y),
                       new Size(sprite.size.Width, sprite.size.Height)));
        }

        public static void RenderedInterface()
        {
            foreach(var button in Core.Scenes[CurrentSceneID].AllButtons)
            {
                Window.Controls.Add(button);
            }
            foreach (var label in Core.Scenes[CurrentSceneID].AllLabels)
            {
                Window.Controls.Add(label);
            }
        }

        public static void GetScene(string tag)
        {
            Window.Controls.Clear();
            CurrentSceneID = Core.Scenes.Find(scene => scene.Tag == tag).ID;
        }

        public static void UpdateGameElements()
        {
            foreach (var npcFish in GameScene.Fishes)
            {
                npcFish.OnUpdate();
            }
        }
    }
}
