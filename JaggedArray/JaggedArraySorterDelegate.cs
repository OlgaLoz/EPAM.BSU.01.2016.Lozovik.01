using System;
using System.Collections.Generic;

namespace JaggedArray
{
    public static class JaggedArraySorterDelegate
    {
        public static void Sort(int[][] arrayToSort, ComparatorDelegate сomparator)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException(nameof(arrayToSort));
            }

            if (сomparator == null)
            {
                throw new ArgumentNullException(nameof(сomparator));
            }

            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                for (int j = 0; j < arrayToSort.Length - i - 1; j++)
                {
                    if (arrayToSort[j] == null ||
                        arrayToSort[j + 1] != null && arrayToSort[j + 1].Length != 0 &&
                        (arrayToSort[j].Length == 0 || сomparator(arrayToSort[j], arrayToSort[j + 1]) > 0))
                    {
                        Swap(ref arrayToSort[j], ref arrayToSort[j + 1]);
                    }
                }
            }
        }

        public static void Sort(int[][] arrayToSort, IComparer<int[]> comparator)
        {
            if (comparator == null)
            {
                 throw new ArgumentNullException(nameof(comparator));
            }
            Sort(arrayToSort, comparator.Compare);
        }

        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] tempArray = array1;
            array1 = array2;
            array2 = tempArray;
        }
    }
}
