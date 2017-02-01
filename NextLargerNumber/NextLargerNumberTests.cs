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

        [TestMethod]
        public void Test_517_should_return_571()
        {
            var input = 517;
            var expected = 571;

            var actual = NextLargerNumber.Next(input);
            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [TestMethod]
        public void Test_132_should_return_231()
        {
        }
    }

    public static class NextLargerNumber
    {
        internal static int Next(int input)
        {
            var numbers = input.ToString().ToCharArray().ToList();

            var largestNumbers = numbers.OrderByDescending(x => x)
                .Select(x => (int)char.GetNumericValue(x)).ToList();

            var largetNumber = GetNumbericFromValueList(largestNumbers);
            if (CheckIfOnlyOneNumber(numbers) || CheckIfAlreadyLargestNumber(input, largetNumber))
            {
                return -1;
            }

            return largetNumber;
        }

        private static bool CheckIfAlreadyLargestNumber(int input, int number)
        {
            return number == input;
        }

        private static bool CheckIfOnlyOneNumber(List<char> numbers)
        {
            return numbers.Distinct().Count() == 1;
        }

        private static int GetNumbericFromValueList(List<int> numbers)
        {
            var count = numbers.Count;

            var result = numbers.Select((x, index) => { return x * (Math.Pow(10, (count - index - 1))); }).Sum();
            return Convert.ToInt32(result);
        }
    }
}