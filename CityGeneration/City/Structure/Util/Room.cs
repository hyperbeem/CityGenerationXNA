using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CityGeneration.City.Structure.Util
{
    public abstract class Room
    {
        private int sizeX;
        private int sizeY;

        private bool generated;
        public bool Generated
        {
            get { return generated; }
            set { generated = value; }
        }

        public Room(int SizeX, int SizeY)
        {
            generated = false;
            sizeX = SizeX;
            sizeY = SizeY;
            Generate();
        }

        public abstract void Generate();
        public abstract void Update();
        public abstract void Draw();
    }
}
