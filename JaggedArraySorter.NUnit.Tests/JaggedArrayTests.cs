using System;
using System.Linq;
using JaggedArray;
using NUnit.Framework;
using static JaggedArray.JaggedArraySorter;

namespace JaggedArraySorter.NUnit.Tests
{
    public class SumSorter : ISortCategory
    {
        public int Category(int[] array) => array.Sum();
    }

    public class MaxSorter : ISortCategory
    {
        public int Category(int[] array) => array.Max();
    }

    public class Ascending : IComparator
    {
        public bool Compare(int a, int b) => a > b;
    }

    public class Descending : IComparator
    {
        public bool Compare(int a, int b) => a < b;
    }


    [TestFixture]
    public class JaggedArrayTests
    {
        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Sort_NullArray()
        {
            Sort(null, new MaxSorter(), new Ascending());
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Sort_NullSortCategory()
        {
            Sort(new []{new []{1, 2}, new []{3, 4}}, null, new Ascending());
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Sort_NullComparator()
        {
            Sort(new[] { new[] { 1, 2 }, new[] { 3, 4 } }, null, new Ascending());
        }

        [TestCase]
        public void Sort_ByMax_Ascending()
        {
            int[][] expected = { new[] { 3, 4 } , new[] { 1, 8 }};
            int[][] actual = { new[] { 1, 8 }, new[] { 3, 4 } };
            Sort(actual, new MaxSorter(), new Ascending());
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_ByMax_Desscending()
        {
            int[][] expected = { new[] { 9, 25, 4 }, new[] { 1, 8 }, new[] { 3, 4 } };
            int[][] actual = { new[] { 1, 8 }, new[] { 9, 25, 4 }, new[] { 3, 4 } };
            Sort(actual, new MaxSorter(), new Descending());
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_BySum_Ascending()
        {
            int[][] expected = { new[] { 3, 4 }, new[] { 1, 8 }, new [] {15} };
            int[][] actual = { new[] { 1, 8 }, new[] { 15 }, new[] { 3, 4 } };
            Sort(actual, new SumSorter(), new Ascending());
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_BySum_Descending()
        {
            int[][] expected = { new[] { 1, 8 }, new[] { 2, 5 }, new []{0, 0} };
            int[][] actual = {new []{2, 5}, new[] { 1, 8 }, new[] { 0, 0 } };
            Sort(actual, new SumSorter(), new Descending());
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_BySum_Descending_WithNullArray()
        {
            int[][] expected = {new[] { 1, 8 },  new[] { 2, 5 }, new[] { 0, 0 }, null, null };
            int[][] actual = {new[] { 2, 5 }, null, new[] { 1, 8 }, new[] { 0, 0 }, null };
            Sort(actual, new SumSorter(), new Descending());
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Sort_BySum_Descending_WithNullAndEmptyArray()
        {
            int[][] expected = { new[] { 1, 8 }, new[] { 2, 5 }, new[] { 0, 0 }, new int[] {}, new int[] {}, new int[] {}, null, null };
            int[][] actual = { new int[] { }, new[] { 2, 5 }, new int[] { }, null, new[] { 1, 8 }, new int[] { }, new[] { 0, 0 }, null };
            Sort(actual, new SumSorter(), new Descending());
            Assert.AreEqual(expected, actual);
        }
    }
}
