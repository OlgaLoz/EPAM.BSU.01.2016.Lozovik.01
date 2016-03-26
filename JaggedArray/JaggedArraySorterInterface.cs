using System;
using System.Collections.Generic;

namespace JaggedArray
{
    public delegate int ComparatorDelegate(int[] array1, int[] array2);

    public static class  JaggedArraySorterInterface
    {
        private class DelegateClass:IComparer<int[]>
        {
            public ComparatorDelegate Comparator { get; set; }

            public int Compare(int[] x, int[] y)
            {
                return Comparator(x, y);
            }
        }

        public static void Sort(int[][] arrayToSort, IComparer<int[]> comparator)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException(nameof(arrayToSort));
            }

            if (comparator == null)
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            for (int i = 0; i < arrayToSort.Length - 1; i++)
            {
                for (int j = 0; j < arrayToSort.Length - i - 1; j++)
                {
                    if ( arrayToSort[j] == null || 
                        arrayToSort[j + 1] != null && arrayToSort[j + 1].Length != 0 &&
                        (arrayToSort[j].Length == 0 || comparator.Compare(arrayToSort[j], arrayToSort[j + 1]) > 0))
                    {
                        Swap(ref arrayToSort[j], ref arrayToSort[j + 1]);
                    }
                }
            }
        }

        public static void Sort(int[][] arrayToSort,  ComparatorDelegate comparator)
        {
            if (comparator == null)
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            DelegateClass delegateClass = new DelegateClass {Comparator = comparator};
            Sort(arrayToSort,  delegateClass);
        }

        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] tempArray = array1;
            array1 = array2;
            array2 = tempArray;
        } 
    }  
}
