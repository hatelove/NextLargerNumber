using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void Test_23_should_return_32()
        {
            var input = 23;
            var expected = 32;
            var actual = NextLargerNumber.Next(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_32_should_return_minus_1()
        {
            var input = 32;
            var expected = -1;

            var actual = NextLargerNumber.Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_666_should_return_minus_1()
        {
            var input = 666;
            var expected = -1;
            var actual = NextLargerNumber.Next(input);
            Assert.AreEqual(expected, actual);
        }
    }

    public static class NextLargerNumber
    {
        internal static int Next(int input)
        {
            var numbers = input.ToString().ToCharArray().OrderByDescending(x => x).Select(x => (int)Char.GetNumericValue(x)).ToList();
            if (CheckIfOnlyOneNumber(numbers) || CheckIfAlreadyLargestNumber(input, numbers))
            {
                return -1;
            }

            return GetNumberFromChars(numbers);
        }

        private static bool CheckIfAlreadyLargestNumber(int input, List<int> numbers)
        {
            return GetNumberFromChars(numbers) == input;
        }

        private static bool CheckIfOnlyOneNumber(List<int> numbers)
        {
            return numbers.Distinct().Count() == 1;
        }

        private static int GetNumberFromChars(List<int> numbers)
        {
            var count = numbers.Count;

            var result = numbers.Select((x, index) => { return x * (Math.Pow(10, (count - index - 1))); }).Sum();
            return Convert.ToInt32(result);
        }
    }
}