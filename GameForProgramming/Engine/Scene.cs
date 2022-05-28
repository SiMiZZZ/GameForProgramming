using GameForProgramming.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameForProgramming.Engine
{
    public abstract class Scene
    {
        public List<Sprite2D> AllSprites = new List<Sprite2D>();
        public List<Button> AllButtons = new List<Button>();
        public List<Label> AllLabels = new List<Label>();
        public static int  SceneID = 0;
        public readonly int ID;
        public string Tag;

        public Scene(string tag)
        {
            ID = SceneID;
            SceneID++;
            Tag = tag;
            Core.Scenes.Add(this);
        }

        public void RegisterObject(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
        }

        public void RegisterObject(NPCFish npcFish)
        {
            AllSprites.Add(npcFish.sprite);
        }

        public void RegisterObject(Button button)
        {
            AllButtons.Add(button);
        }

        public void UnRegisterObject(Sprite2D sprite)
        {
            AllSprites.Remove(sprite);
        }

        public void RegisterObject(Label label)
        {
            AllLabels.Add(label);
        }

        public void UnRegisterObject(NPCFish npcFish)
        {
            AllSprites.Remove(npcFish.sprite);
            npcFish.sprite.position = new Point(10000, 10000);
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();

    }
}
