using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NextLargerNumber
{
    [TestClass]
    public class NextLargerNumberTests
    {
        [TestMethod]
        public void Test_1_should_be_minus_1()
        {
            var input = 1;

            var expected = -1;

            int actual = NextLargerNumber.Next(input);

            Assert.AreEqual(expected, actual);

        }
    }

    public static class NextLargerNumber
    {
        internal static int Next(int input)
        {
            throw new NotImplementedException();
        }
    }
}
