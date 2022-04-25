using System;
using System.Threading.Channels;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            for(int i = 0; i < 10; i++)
                array[i] = new Random().Next(0, 100);
            
            Console.WriteLine("Start list of ships:");
            Console.WriteLine($"{String.Join(", ", array)}");
            Sorting.InsertionSort(ref array);
            Console.WriteLine();
            Console.WriteLine("After Sorting:");
            foreach (var item in array)
                Console.Write($"{item}, ");
            
        }
    }
}
