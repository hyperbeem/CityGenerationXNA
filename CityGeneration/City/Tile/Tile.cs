using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using CityGeneration.City.Tile.Util;

namespace CityGeneration.City.Tile
{

    public abstract class Tile
    {
        public int tileDim = 32;

        protected Location2 _TileLocation;

        private Texture2D _Texture;
        public Texture2D GetTexture
        {
            get { return _Texture; }
            protected set { _Texture = value; }
        }

        private int _Meta;
        public int GetMeta
        {
            get { return _Meta; }
        }

        private Rectangle _DrawBox;
        public Rectangle GetDrawBox
        {
            get { return _DrawBox; }
            set { _DrawBox = value; }
        }

        public Tile(int meta, Location2 tileLocation)
        {
            _Meta = meta;
            _TileLocation = tileLocation;
        }

        public Tile(int meta, int x, int y)
        {
            _Meta = meta;
            _TileLocation.X = x;
            _TileLocation.Y = y;
        }

        public abstract void Load();
        public abstract void Update();
        public abstract void Draw(SpriteBatch sb);
    }
}
