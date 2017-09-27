using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using CityGeneration;

namespace CityGeneration.City.Tile.Types
{
    public class Floor : Tile
    {
        public Floor(int meta) : base (meta)
        {
            Load();
            SetRectangle(meta);
        }

        private void SetRectangle(int meta )
        {
            int tX = meta / (GetTexture.Width / tileDim);
            int tY = meta % (GetTexture.Width / tileDim);

            GetDrawBox = new Rectangle(tX * tileDim, tY * tileDim, tileDim, tileDim);
        }

        public override void Load()
        {
            ContentManager cm = Game1.serviceContainer.GetService<ContentManager>();
            GetTexture = cm.Load<Texture2D>("Testsheet");
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Draw(int offsetX, int offsetY,int x, int y, SpriteBatch sb)
        {
            sb.Draw(GetTexture, new Vector2((float)(offsetX * tileDim) + (x * tileDim), (float)(offsetY * tileDim) + (y * tileDim)), GetDrawBox, Color.White);
        }
    }
}
