using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NextLargerNumber
{
    [TestClass]
    public class NextLargerNumberTests
    {
        private const int NoLargerNumber = -1;

        [TestMethod]
        public void Test_1_should_be_largestNumber()
        {
            var input = 1;

            var expected = NoLargerNumber;

            int actual = GetNextLargerNumber(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_23_should_return_32()
        {
            var input = 23;
            var expected = 32;
            var actual = GetNextLargerNumber(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_32_should_be_largestNumber()
        {
            var input = 32;
            var expected = NoLargerNumber;

            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_666_should_be_largestNumber()
        {
            var input = 666;
            var expected = NoLargerNumber;
            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_517_should_return_571()
        {
            var input = 517;
            var expected = 571;

            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_132_should_return_213()
        {
            var input = 132;
            var expected = 213;

            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_231_should_return_312()
        {
            var input = 231;
            var expected = 312;

            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_10231_should_return_10312()
        {
            var input = 10231;
            var expected = 10312;

            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_2543_should_return_3245()
        {
            var input = 2543;
            var expected = 3245;
            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_54321_should_be_largestNumber()
        {
            var input = 54321;
            var expected = NoLargerNumber;
            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_12321_should_return_13122()
        {
            var input = 12321;
            var expected = 13122;
            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_11200_should_return_12001()
        {
            var input = 11200;
            var expected = 12001;
            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_15963_should_return_16359()
        {
            var input = 15963;
            var expected = 16359;
            var actual = GetNextLargerNumber(input);
            Assert.AreEqual(expected, actual);
        }

        private static int GetNextLargerNumber(int input)
        {
            return NextLargerNumber.Next(input);
        }
    }

    public class NextLargerNumber
    {
        internal static int Next(int input)
        {
            var inputNumbers = input.ToString().ToCharArray().Select(x => (int)char.GetNumericValue(x)).ToList();

            for (int index = inputNumbers.Count - 1; index > 0; index--)
            {
                var rightIndex = index;
                var leftIndex = rightIndex - 1;

                if (inputNumbers[rightIndex] <= inputNumbers[leftIndex])
                {
                    continue;
                }
                else
                {
                    var result = SwappedList(inputNumbers, leftIndex, rightIndex);
                    return GetNumbericFromValueList(result);
                }
            }

            return -1;
        }

        private static List<int> SwappedList(List<int> inputNumbers, int leftIndex, int index)
        {
            var leftLength = leftIndex + 1;
            var leftLit = inputNumbers.GetRange(0, leftLength);

            var rightLength = inputNumbers.Count - leftLength;
            var rightList = inputNumbers.GetRange(index, rightLength);

            var leftForSwap = inputNumbers[leftIndex];

            for (int i = rightList.Count - 1; i >= 0; i--)
            {
                if (rightList[i] > leftForSwap)
                {
                    leftLit[leftIndex] = rightList[i];
                    rightList[i] = leftForSwap;
                    break;
                }
            }

            leftLit.AddRange(rightList.OrderBy(x => x));
            return leftLit;
        }

        private static int GetNumbericFromValueList(IEnumerable<int> numbers)
        {
            var count = numbers.Count();

            var result = numbers.Select((x, index) => x * (Math.Pow(10, (count - index - 1)))).Sum();
            return Convert.ToInt32(result);
        }
    }
}