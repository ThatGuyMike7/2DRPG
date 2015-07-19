using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace RPG
{
    class Tilemap : Drawable
    {
        private Texture tileset;
        private VertexArray vertexArray;

        private int width;
        private int height;
        private float tileTextureDimension;
        private float tileWorldDimension;

        public Tilemap(Texture tileset, int width, int height, float tileTextureDimension, float tileWorldDimension)
        {
            this.tileset = tileset;

            this.width = width;
            this.height = height;
            this.tileTextureDimension = tileTextureDimension;
            this.tileWorldDimension = tileWorldDimension;

            vertexArray = new VertexArray(PrimitiveType.Quads, (uint)(width * height * 4));

            Tile tile = new Tile(1, 2, Color.White);
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    AddTileVertices(tile, new Vector2f((float)x, (float)y));
                }
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = tileset;
            target.Draw(vertexArray, states);
        }

        private void AddTileVertices(Tile tile, Vector2f position)
        {
            vertexArray.Append(new Vertex((new Vector2f(0.0f, 0.0f) + position) * tileWorldDimension,
                new Vector2f(tileTextureDimension * tile.X, tileTextureDimension * tile.Y)));  
 
            vertexArray.Append(new Vertex((new Vector2f(1.0f, 0.0f) + position) * tileWorldDimension
                , new Vector2f(tileTextureDimension * tile.X + tileTextureDimension, tileTextureDimension * tile.Y))); 

            vertexArray.Append(new Vertex((new Vector2f(1.0f, 1.0f) + position) * tileWorldDimension,
                new Vector2f(tileTextureDimension * tile.X + tileTextureDimension, tileTextureDimension * tile.Y + tileTextureDimension)));

            vertexArray.Append(new Vertex((new Vector2f(0.0f, 1.0f) + position) * tileWorldDimension,
                new Vector2f(tileTextureDimension * tile.X, tileTextureDimension * tile.Y + tileTextureDimension)));
        }
    }
}
