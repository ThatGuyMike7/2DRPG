using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace RPG
{
    class Tile
    {
        // Position in the tileset
        public int X;
        public int Y;

        // Which color in map file represents this tile
        public Color color;

        public Tile(int X, int Y, Color color)
        {
            this.X = X;
            this.Y = Y;
            this.color = color;
        }
    }
}
