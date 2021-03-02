using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    class ColorCoderTest
    {

        private static void Main(string[] args)
        {
            ColorCoderTest colorCoderTest = new ColorCoderTest();

            colorCoderTest.DisplayPairNumber(4, Color.White, Color.Brown);
            colorCoderTest.DisplayPairNumber(5, Color.White, Color.SlateGray);
            colorCoderTest.DisplayPairNumber(23, Color.Violet, Color.Green);

            ColorPairGroup colorPair = new ColorPairGroup() { majorColor = Color.Yellow, minorColor = Color.Green };
            colorCoderTest.DisplayColor(colorPair, 18);

            colorPair = new ColorPairGroup() { majorColor = Color.Red, minorColor = Color.Blue };
            colorCoderTest.DisplayColor(colorPair, 6);

            Console.WriteLine("COLOR PAIR REFERENCE MANUAL:\n");
            ColorPairMappingReference.ColorPairReferenceManual();
        }

        public void DisplayPairNumber(int pairNumber, Color expectedMajor, Color expectedMinor)
        {
            ColorPairGroup testPair = ColorPairMappingReference.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair);
            Debug.Assert(testPair.majorColor == expectedMajor);
            Debug.Assert(testPair.minorColor == expectedMinor);
        }

        public void DisplayColor(ColorPairGroup colorPairGroup, int expectedPairNumber)
        {
            int pairNumber = ColorPairMappingReference.GetPairNumberFromColor(colorPairGroup);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", colorPairGroup, pairNumber);
            Debug.Assert(pairNumber == expectedPairNumber);
        }
    }
}