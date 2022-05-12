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
            int index;
            for (int i = 1; i < array.Length; i++)
            {
                for (index = i; index > 0; index--)
                    if (array[index] < array[index - 1])
                        (array[index - 1], array[index]) = (array[index], array[index - 1]);
                    else break;
            }
        }
        public static int[] ShellSort(ref int[] array)
        {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            return array;
        }
        static void Swap(ref int a, ref int b) => (a, b) = (b, a);
        
        static void CountingSort(int[] Array) {
            int n = Array.Length;
            int max = 0;
            for (int i=0; i<n; i++) {  
                if(max < Array[i]) {
                    max = Array[i];
                } 
            }
            int[] freq = new int[max+1];
            for (int i=0; i<max+1; i++) {  
                freq[i] = 0;
            } 
            for (int i=0; i<n; i++) {  
                freq[Array[i]]++;
            }
            for (int i=0, j=0; i<=max; i++) {  
                while(freq[i]>0) { 
                    Array[j] = i;
                    j++;
                    freq[i]--;
                }
            }
        }
    }
}