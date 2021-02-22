using System;
using System.Collections.Generic;
using System.Text;

namespace TelCo.ColorCoder
{
    public class ColorCoderFunction : ColorPairMapping
    {
        public static ColorPairMapping GetColorFromPairNumber(int pairNumber)
        {
            if (pairNumber < 1 || pairNumber > colorMapMinor.Length * colorMapMajor.Length)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            ColorPairMapping pair = new ColorPairMapping()
            {
                majorColor = colorMapMajor[pairNumber - 1 / colorMapMinor.Length],
                minorColor = colorMapMinor[pairNumber - 1 % colorMapMajor.Length]
            };

            return pair;
        }

        public static int GetPairNumberFromColor(ColorPairMapping pair)
        {
            int majorIndex = -1;
            for (int i = 0; i < colorMapMajor.Length; i++)
            {
                if (colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }
            int minorIndex = -1;
            for (int i = 0; i < colorMapMinor.Length; i++)
            {
                if (colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            }
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }
    }
}
