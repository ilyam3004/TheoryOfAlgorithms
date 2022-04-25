using System;

namespace Lab9
{
    public class Sorting
    { 
        public static void BubleSort(ref int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length -1 ; j++)
                {
                    if(array[j] > array[j+1])
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        public static int[] QuickSort(ref int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return array;
            int pivot = GetPivotIndex(array, minIndex, maxIndex);
            QuickSort(ref array, minIndex, pivot - 1);
            QuickSort(ref array, pivot + 1, maxIndex);
            return array;
        }
        private static int GetPivotIndex(int[] array, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    (array[pivot], array[i]) = (array[i], array[pivot]);
                }
            }
            pivot++;
            (array[pivot], array[maxIndex]) = (array[maxIndex], array[pivot]);
            return pivot;
        }
        public static void InsertionSort(ref int[] array)
        {
            int temp, index;
            for (int i = 1; i < array.Length; i++)
            {
                for (index = i; index > 0; index--)
                    if (array[index] < array[index - 1])
                    {
                        temp = array[index - 1];
                        array[index - 1] = array[index];
                        array[index] = temp;
                    }
                    else break;
            }
        }
    }
}