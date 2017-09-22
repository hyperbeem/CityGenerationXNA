using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CityGeneration.Util
{
    public class Rand
    {
        private static readonly RNGCryptoServiceProvider _gen = new RNGCryptoServiceProvider();

        public static int Random(int min, int max)
        {
            byte[] randomSeed = new byte[1];
            _gen.GetBytes(randomSeed);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomSeed[0]);
            // We are using Math.Max, and substracting 0.00000000001, 
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            int range = max - min + 1;
            double randomValInRange = Math.Floor(multiplier * range);
            return (int)(min + randomValInRange);
        }

        public static double RandomNoise(int x, int y)
        {
            var n = x + y * 57;
            n = (n << 13) ^ n;
            return (1.0 - ((n * (n * n * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0);
        }
    }
}
