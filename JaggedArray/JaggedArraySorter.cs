using System;

namespace JaggedArray
{
    public static class  JaggedArraySorter
    {
        public delegate int CategoryFunctionDelegate(int[] array);

        public delegate bool SortDirectionDelegate(int x, int y);

        public static SortDirectionDelegate DescDirection => Descending;

        public static SortDirectionDelegate AscDirection => Ascending;

        public static  CategoryFunctionDelegate SortBySum => SearchSum;

        public static CategoryFunctionDelegate SortByMax => SearchMax;

        public static CategoryFunctionDelegate SortByMin => SearchMin;

        public static void SortByCategory(int[][] arrayToSort, CategoryFunctionDelegate categoryFunction, SortDirectionDelegate sortDirection)
        {
            if (arrayToSort == null)
                throw new ArgumentNullException();

            int length = FindNullsAndEmpty(arrayToSort);
            int[] categoryArray = CreateCategoryArray(arrayToSort, length, categoryFunction);
            Sort(arrayToSort, categoryArray, sortDirection);
        }

        private static void Sort(int[][] arrayToSort, int[] categoryArray, SortDirectionDelegate sortDirection)
        {            
            for (int i = 0; i < categoryArray.Length - 1; i++)
            {
                for (int j = 0 ; j < categoryArray.Length - i - 1; j++)
                {
                    if (sortDirection(categoryArray[j], categoryArray[j + 1]))
                    {
                        Swap(arrayToSort, j + 1 , j);
                        Swap(categoryArray, j + 1, j);
                    }                   
                }                
            }
        }

        private static void Swap(int[][] array, int firstIndex, int secondIndex)
        {
            int[] tempArray = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = tempArray;
        }

        private static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        private static int FindNullsAndEmpty(int[][] array)
        {
            int index = array.Length;
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i]==null)
                {
                    index--;
                    Swap(array, i, index);                    
                }
            }

            for (int i = index - 1; i >= 0; i--)
            {
                if (array[i].Length ==0)
                {
                    index--;
                    Swap(array, i, index);
                }
            }
            return index;
        }

        private static int SearchSum(int[] array)                   
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        private static int SearchMin(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        private static int SearchMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        private static int[] CreateCategoryArray(int[][] array, int length, CategoryFunctionDelegate categoryFunction )
        {
            int[] result = new int[length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = categoryFunction(array[i]);
            }
            return result;
        }

        private static bool Descending(int x, int y) => x < y;

        private static bool Ascending(int x, int y) => x > y;
    }
}
