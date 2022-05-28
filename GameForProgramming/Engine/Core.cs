using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameForProgramming.Properties;

namespace GameForProgramming.Engine
{
    public class Core
    {
        public static List<Scene> Scenes = new List<Scene>();

       
        

        public static Button CreateButton(int width, int height, int x, int y, string text, Bitmap texture = null, bool IsText = true)
        {

            Button button = new Button
            {
                Size = new Size(width, height),
                Location = new Point(x, y),
                Name = text,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                BackgroundImage = texture,
                BackgroundImageLayout = ImageLayout.Stretch,
            };
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            return button;
        }

        public static Label CreateLabel(int width, int height, int x, int y, string text)
        {
            System.Drawing.Text.PrivateFontCollection f = new System.Drawing.Text.PrivateFontCollection();
           // f.AddFontFile("font.ttf");
            Label label = new Label
            {
                Size = new Size(width, height),
                Location = new Point(x, y),
                Font = new Font("font", 30),
                Text = text,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            return label;
        }
    }
}
