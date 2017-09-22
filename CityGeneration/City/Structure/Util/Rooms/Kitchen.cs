using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CityGeneration.Util;

namespace CityGeneration.City.Structure.Util.Rooms
{
    public class Kitchen : Room
    {
        public Kitchen(int sizeX, int sizeY) : base(sizeX,sizeY)
        {

        }

        public override void Generate()
        {
            if(!Generated)
            {
                Generated = true;

            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
