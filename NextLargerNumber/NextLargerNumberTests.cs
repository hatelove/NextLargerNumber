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

            int actual = CreateNextLargerNumber().Next(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_23_should_return_32()
        {
            var input = 23;
            var expected = 32;
            var actual = CreateNextLargerNumber().Next(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_32_should_return_minus_1()
        {
            var input = 32;
            var expected = -1;

            var actual = CreateNextLargerNumber().Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_666_should_return_minus_1()
        {
            var input = 666;
            var expected = -1;
            var actual = CreateNextLargerNumber().Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_517_should_return_571()
        {
            var input = 517;
            var expected = 571;

            var actual = CreateNextLargerNumber().Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_132_should_return_213()
        {
            var input = 132;
            var expected = 213;

            var actual = CreateNextLargerNumber().Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_231_should_return_312()
        {
            var input = 231;
            var expected = 312;

            var actual = CreateNextLargerNumber().Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_10231_should_return_10312()
        {
            var input = 10231;
            var expected = 10312;

            var actual = CreateNextLargerNumber().Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_2543_should_return_3245()
        {
            var input = 2543;
            var expected = 3245;
            var actual = CreateNextLargerNumber().Next(input);
            Assert.AreEqual(expected, actual);
        }

        private static NextLargerNumber CreateNextLargerNumber()
        {
            return new NextLargerNumber();
        }
    }

    public class NextLargerNumber
    {
        internal int Next(int input)
        {
            var numbers = input.ToString().ToCharArray().Select(x => (int)char.GetNumericValue(x)).ToList();

            var rightIndex = numbers.Count - 1;

            SwapWhenRightLargerThanLeftElement(numbers, rightIndex, rightIndex - 1);

            var result = GetNumbericFromValueList(resultList);
            return result == input ? -1 : result;
        }

        private void SwapWhenRightLargerThanLeftElement(List<int> numbers, int rightIndex, int leftIndex)
        {
            rightList.Add(numbers[rightIndex]);

            if (leftIndex < 0)
            {
                resultList.AddRange(rightList.OrderByDescending(x => x));
                return;
            }

            if (numbers[rightIndex] > numbers[leftIndex])
            {
                resultList.AddRange(numbers.GetRange(0, leftIndex));

                var valueForSwapFromRight = rightList.Where(x => x > numbers[leftIndex]).Min();

                rightList.Remove(valueForSwapFromRight);
                rightList.Add(numbers[leftIndex]);

                resultList.Add(valueForSwapFromRight);
                resultList.AddRange(rightList.OrderBy(x => x).ToList());

                return;
            }

            SwapWhenRightLargerThanLeftElement(numbers, leftIndex, leftIndex - 1);
        }

        private List<int> rightList = new List<int>();
        private List<int> resultList = new List<int>();

        private static bool CheckIfAlreadyLargestNumber(int input, int number)
        {
            return number == input;
        }

        private static bool CheckIfOnlyOneNumber(List<int> numbers)
        {
            return numbers.Distinct().Count() == 1;
        }

        private static int GetNumbericFromValueList(IEnumerable<int> numbers)
        {
            var count = numbers.Count();

            var result = numbers.Select((x, index) => x * (Math.Pow(10, (count - index - 1)))).Sum();
            return Convert.ToInt32(result);
        }
    }
}