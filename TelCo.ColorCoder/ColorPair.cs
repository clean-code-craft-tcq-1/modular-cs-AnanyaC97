using System;
using System.Collections.Generic;
using System.Text;

namespace TelCo.ColorCoder
{
    class ColorPair
    {

        private static Color[] colorMapMajor;

        private static Color[] colorMapMinor;

        internal class ColorPair
        {
            internal Color majorColor;
            internal Color minorColor;
            public override string ToString()
            {
                return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
            }
        }
        /// <summary>
        /// Static constructor required to initialize static variable
        /// </summary>
        static ColorPair()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

    }
}
