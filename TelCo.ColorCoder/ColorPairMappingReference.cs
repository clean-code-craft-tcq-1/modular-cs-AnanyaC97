using System;
using System.Collections.Generic;
using System.Text;

namespace TelCo.ColorCoder
{
    public class ColorPairMappingReference : ColorPairGroup
    {
        public static ColorPairGroup GetColorFromPairNumber(int pairNumber)
        {
            if (pairNumber < 1 || pairNumber > (colorMapMinor.Length * colorMapMajor.Length))
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            ColorPairGroup pair = new ColorPairGroup()
            {
                majorColor = colorMapMajor[(pairNumber - 1) / colorMapMinor.Length],
                minorColor = colorMapMinor[(pairNumber - 1) % colorMapMajor.Length]
            };

            return pair;
        }

        public static int GetPairNumberFromColor(ColorPairGroup pair)
        {

            int majorIndex = GetMajorIndex(pair);
            int minorIndex = GetMinorIndex(pair);

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }

        public static void ColorPairReferenceManual()
        {
            for (int i = 1; i <= (colorMapMinor.Length * colorMapMajor.Length); i++)
                Console.WriteLine("Pair Number: {0}, Colors: {1}\n", i, GetColorFromPairNumber(i));
        }
    }
}
