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

        [TestMethod]
        public void Test_132_should_return_213()
        {
            var input = 132;
            var expected = 213;

            var actual = NextLargerNumber.Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_231_should_return_312()
        {
            var input = 231;
            var expected = 312;

            var actual = NextLargerNumber.Next(input);
            Assert.AreEqual(expected, actual);
        }
    }

    public static class NextLargerNumber
    {
        internal static int Next(int input)
        {
            resultList.Clear();
            rightList.Clear();

            var numbers = input.ToString().ToCharArray().Select(x => (int)char.GetNumericValue(x)).ToList();

            //for more easily refactoring
            int result = 0;

            var largestNumbers = numbers.OrderByDescending(x => x);

            var largetNumber = GetNumbericFromValueList(largestNumbers);
            if (CheckIfOnlyOneNumber(numbers) || CheckIfAlreadyLargestNumber(input, largetNumber))
            {
                result = -1;
            }
            else
            {
                var rightIndex = numbers.Count - 1;
                var leftIndex = rightIndex - 1;

                SwapWhenRightLargerThanLeftElement(ref numbers, rightIndex, leftIndex);

                result = GetNumbericFromValueList(numbers);
            }

            return result;
        }

        private static void SwapWhenRightLargerThanLeftElement(ref List<int> numbers, int rightIndex, int leftIndex)
        {
            if (numbers[rightIndex] > numbers[leftIndex])
            {
                var temp = numbers[rightIndex];
                numbers[rightIndex] = numbers[leftIndex];
                numbers[leftIndex] = temp;
            }
            else
            {
                rightList.Add(numbers[rightIndex]);

                var newRightIndex = leftIndex;
                var newLeftIndex = leftIndex - 1;

                var newLeftValue = numbers[newLeftIndex];
                var newRightValue = numbers[newRightIndex];
                if (newRightValue > newLeftValue)
                {
                    rightList.Add(newRightValue);

                    var valueForSwapFromRight = rightList.Where(x => x > newLeftValue).Min();
                    //var rightIndexForSwap = numbers.FindIndex(x => x == valueForSwapFromRight);

                    rightList.Remove(valueForSwapFromRight);
                    rightList.Add(newLeftValue);

                    resultList.Add(valueForSwapFromRight);
                    resultList.AddRange(rightList.OrderBy(x => x).ToList());
                    numbers = new List<int>(resultList);
                }
            }
        }

        private static List<int> rightList = new List<int>();
        private static List<int> resultList = new List<int>();

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