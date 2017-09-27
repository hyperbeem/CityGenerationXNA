using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Update()
        {
            foreach (Tile t in _Background)
                t.Update();
            foreach (Tile t in _Decoration)
                t.Update();
        }

        public void Draw()
        {

        }
    }
}
