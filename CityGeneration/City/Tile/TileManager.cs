using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CityGeneration.City.Tile.Util;
using CityGeneration.City.Tile.Types;
using Microsoft.Xna.Framework.Graphics;

namespace CityGeneration.City.Tile
{
    public enum TileType
    {
        Floor,
        Decor
    };

    public class TileManager
    {
        private readonly List<Tile> _Background;
        private readonly List<Tile> _Decoration;

        public TileManager()
        {
            _Background = new List<Tile>();
            _Decoration = new List<Tile>();
        }

        public void AddBackgroundTile(int meta, int x, int y)
        {
            var f = new Floor(meta, x, y);
            _Background.Add(f);
        }

        public void Update()
        {
            foreach (Tile t in _Background)
                t.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Tile t in _Background)
                t.Draw(sb);
        }
    }
}
