using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using CityGeneration.City.Tile.Util;

using CityGeneration;

namespace CityGeneration.City.Tile.Types
{
    public class Floor : Tile
    {
        public Floor(int meta, Location2 location) : base (meta, location)
        {
            Load();
            SetRectangle(meta);
        }

        public Floor(int meta, int x, int y) : base (meta, x,y)
        {
            Load();
            SetRectangle(meta);
        }

        private void SetRectangle(int meta)
        {
            int tY = meta / (GetTexture.Width / tileDim);
            int tX = meta % (GetTexture.Width / tileDim);

            GetDrawBox = new Rectangle(tX * tileDim, tY * tileDim, tileDim, tileDim);
        }

        public override void Load()
        {
            ContentManager cm = Game1.serviceContainer.GetService<ContentManager>();
            GetTexture = cm.Load<Texture2D>("Testsheet");
        }

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(GetTexture, new Vector2((_TileLocation.X * tileDim),(_TileLocation.Y * tileDim)), GetDrawBox, Color.White);
        }
    }
}
