using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace RPG
{
    class RPG : Game
    {
        Tilemap map;
        Texture tileset;

        public RPG()
            : base(800, 600, "RPG", Color.Cyan)
        {
        }

        protected override void LoadContent()
        {
            tileset = new Texture("Content/tileset.png");
        }

        protected override void Initialize()
        {
            map = new Tilemap(tileset, 10, 20, 16.0f, 32.0f);
        }

        protected override void Tick()
        {
        }

        protected override void Render()
        {
            window.Draw(map);
        }
    }
}
