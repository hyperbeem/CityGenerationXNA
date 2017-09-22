using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CityGeneration.City.Tile
{
    public abstract class Tile
    {
        private Texture2D _Texture;
        public Texture2D GetTexture
        {
            get { return _Texture; }
        }

        private int _Meta;
        public int GetMeta
        {
            get { return _Meta; }
        }

        public int tileDim = 16;

        private Rectangle _DrawBox;
        public Rectangle GetDrawBox
        {
            get { return _DrawBox; }
            set { _DrawBox = value; }
        }

        public Tile(int meta)
        {
            _Meta = meta;
        }

        public abstract void Load();
        public abstract void Update();
        public abstract void Draw(int offsetX, int offsetY, int x, int y, SpriteBatch sb);
    }
}
