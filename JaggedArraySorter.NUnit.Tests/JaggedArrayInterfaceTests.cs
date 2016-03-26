using System;
using System.Linq;
using JaggedArray;
using NUnit.Framework;


namespace JaggedArraySorter.NUnit.Tests
{
    [TestFixture]
    public class JaggedArrayInterfaceTests
    {
        private int AscendingBySum(int[] a, int[] b) => a.Sum() > b.Sum() ? 1 : -1;

        private int DescendingByMax(int[] a, int[] b) => a.Max() < b.Max() ? 1 : -1;

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Sort_NullArray()
        {
            JaggedArraySorterInterface.Sort(null, AscendingBySum);            
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Sort_NullComparator()
        {
            ComparatorDelegate ascendingBySum = null;
            JaggedArraySorterInterface.Sort(new[] { new[] { 1, 2 }, new[] { 3, 4 } },  ascendingBySum);
        }

        [TestCase]
        public void Sort_ByMax_Ascending()
        {
            int[][] expected = { new[] { 3, 4 } , new[] { 1, 8 }};
            int[][] actual = { new[] { 1, 8 }, new[] { 3, 4 } };
            JaggedArraySorterInterface.Sort(actual, AscendingBySum);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_ByMax_Desscending()
        {
            int[][] expected = { new[] { 9, 25, 4 }, new[] { 1, 8 }, new[] { 3, 4 } };
            int[][] actual = { new[] { 1, 8 }, new[] { 9, 25, 4 }, new[] { 3, 4 } };
            JaggedArraySorterInterface.Sort(actual, DescendingByMax);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_BySum_Ascending()
        {
            int[][] expected = { new[] { 3, 4 }, new[] { 1, 8 }, new [] {15} };
            int[][] actual = { new[] { 1, 8 }, new[] { 15 }, new[] { 3, 4 } };
            JaggedArraySorterInterface.Sort(actual, AscendingBySum);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_BySum_Descending()
        {
            int[][] expected = { new[] { 1, 8 }, new[] { 2, 5 }, new []{0, 0} };
            int[][] actual = {new []{2, 5}, new[] { 1, 8 }, new[] { 0, 0 } };
            JaggedArraySorterInterface.Sort(actual, DescendingByMax);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_BySum_Descending_WithNullArray()
        {
            int[][] expected = {new[] { 1, 8 },  new[] { 2, 5 }, new[] { 0, 0 }, null, null };
            int[][] actual = {new[] { 2, 5 }, null, new[] { 1, 8 }, new[] { 0, 0 }, null };
            JaggedArraySorterInterface.Sort(actual, DescendingByMax);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_BySum_Descending_WithNullAndEmptyArray()
        {
            int[][] expected = { new[] { 1, 8 }, new[] { 2, 5 }, new[] { 0, 0 }, new int[] {}, new int[] {}, new int[] {}, null, null };
            int[][] actual = { new int[] { }, new[] { 2, 5 }, new int[] { }, null, new[] { 1, 8 }, new int[] { }, new[] { 0, 0 }, null };
            JaggedArraySorterInterface.Sort(actual, DescendingByMax);
            Assert.AreEqual(expected, actual);
        }
    }

   
}
