using System;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fleet = new int[10];
            for(int i = 0; i < 10; i++)
                fleet[i] = new Random().Next(100000, 999999);

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("List of sailors in the first flotilla:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            
            Sorting.BucketSort(ref fleet);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("List of sailors in the first flotilla after BucketSorting:");
            Console.WriteLine($"{String.Join(", ", fleet)}");

            int[] secondFleet = new int[10];
            for(int i = 0; i < 10; i++)
                secondFleet[i] = new Random().Next(100000, 999999);
            Array.Resize(ref fleet, 20);
            secondFleet.CopyTo(fleet, 10);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("List of sailors in the first and second flotillas:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("------------------------------------------------------------------------------");
            
            Sorting.LSDSort(ref fleet);
            Console.WriteLine("List of sailors in the first and second flotillas after LSDSorting:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("------------------------------------------------------------------------------"); 
        }
    }
}
