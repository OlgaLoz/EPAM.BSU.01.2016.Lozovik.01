using System;

namespace JaggedArray
{
    public interface ISortCategory
    {
        int Category(int[] array);
    }

    public interface IComparator
    {
        bool Compare(int a, int b);
    }

    public static class  JaggedArraySorter
    {
        public static void Sort(int[][] arrayToSort, ISortCategory sortCategory, IComparator comparator)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException(nameof(arrayToSort));
            }

            if (sortCategory == null)
            {
                throw new ArgumentNullException(nameof(sortCategory));
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
                        (arrayToSort[j].Length == 0 || comparator.Compare(sortCategory.Category(arrayToSort[j]), sortCategory.Category(arrayToSort[j + 1]))))
                    {
                        Swap(ref arrayToSort[j], ref arrayToSort[j + 1]);
                    }
                }
            }
        }

        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] tempArray = array1;
            array1 = array2;
            array2 = tempArray;
        } 
    }
}
