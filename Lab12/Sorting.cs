using System;
using System.Collections.Generic;

namespace Lab12
{
    public class Sorting
    { 
        public static void BucketSort(ref int[] array)
        {
            if (array == null || array.Length < 2)
                return;
            int maxValue = array[0];
            int minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                    maxValue = array[i];
                if (array[i] < minValue)
                    minValue = array[i];
            }
            List<int>[] bucket = new List<int>[maxValue - minValue + 1];
            for (int i = 0; i < bucket.Length; i++)
                bucket[i] = new List<int>();
            for (int i = 0; i < array.Length; i++)
                bucket[array[i] - minValue].Add(array[i]);
            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        array[position] = bucket[i][j];
                        position++;
                    }
                }
            }
        }
        public static void LSDSort(ref int[] array)
        {
            int i, j;
            int[] tmp = new int[array.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < array.Length; ++i)
                {
                    bool move = (array[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)  
                        array[i-j] = array[i];
                    else                            
                        tmp[j++] = array[i];
                }
                Array.Copy(tmp, 0, array, array.Length-j, j);
            }
        }
    }
}