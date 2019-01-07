namespace Gu.Wpf.UiAutomation.UiTests.Input
{
    using System;
    using System.Globalization;
    using Gu.Wpf.UiAutomation.WindowsAPI;
    using NUnit.Framework;

    public class InterpolationTests
    {
        [TestCase("0,0", "100,0", 0, "0,0")]
        [TestCase("0,0", "100,0", 100, "50,0")]
        [TestCase("0,0", "100,0", 195, "100,0")]
        [TestCase("0,0", "100,0", 200, "100,0")]
        [TestCase("0,0", "-100,0", 100, "-50,0")]
        [TestCase("0,0", "-100,0", 195, "-100,0")]
        [TestCase("0,0", "0,100", 100, "0,50")]
        [TestCase("0,0", "0,100", 201, null)]
        public void TryCurrent(string @from, string to, int elapsed, string expected)
        {
            var interpolation = new Interpolation(Parse(from), Parse(to), TimeSpan.FromMilliseconds(200));
            if (expected == null)
            {
                Assert.AreEqual(false, interpolation.TryCurrent(TimeSpan.FromMilliseconds(elapsed), out _));
            }
            else
            {
                Assert.AreEqual(true, interpolation.TryCurrent(TimeSpan.FromMilliseconds(elapsed), out var p));
                Assert.AreEqual(expected, $"{p.X},{p.Y}");
            }
        }

        private static POINT Parse(string text)
        {
            var texts = text.Split(',');
            Assert.AreEqual(2, texts.Length);
            return new POINT(int.Parse(texts[0], CultureInfo.InvariantCulture),
                int.Parse(texts[1], CultureInfo.InvariantCulture));
        }
    }
}
