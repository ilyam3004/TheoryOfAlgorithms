using System;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fleet = new int[10];
            for(int i = 0; i < 10; i++)
                fleet[i] = new Random().Next(10, 99);

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Start list of ships:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            
            Sorting.BubleSort(ref fleet);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Start list of ships after BubleSorting:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Second fleet is arriving...");
            Console.WriteLine("--------------------------------------");
            
            int[] secondFleet = new int[10];
            for(int i = 0; i < 10; i++)
                secondFleet[i] = new Random().Next(10, 99);
            Array.Resize(ref fleet, 20);
            secondFleet.CopyTo(fleet, 10);
            Console.WriteLine("List of ships after arriving the second fleet:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("------------------------------------------------------------------------------");
            
            Sorting.InsertionSort(ref fleet);
            Console.WriteLine("List of ships after InsertingSort:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("------------------------------------------------------------------------------");
            
            Console.WriteLine("Third fleet is arriving...");
            Console.WriteLine("--------------------------------------");
            
            int[] thirdFleet = new int[10];
            for(int i = 0; i < 10; i++)
                thirdFleet[i] = new Random().Next(10, 99);
            Array.Resize(ref fleet, 30);
            thirdFleet.CopyTo(fleet, 20);
            Console.WriteLine("List of ships after arriving the third fleet:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            
            Sorting.QuickSort(ref fleet, 0, fleet.Length - 1);
            Console.WriteLine("List of ships after QuickSort:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            
            int[] fouthFleet = new int[10];
            for(int i = 0; i < 10; i++)
                fouthFleet[i] = new Random().Next(10, 99);
            Array.Resize(ref fleet, 40);
            fouthFleet.CopyTo(fleet, 30);
            Console.WriteLine("List of ships after arriving the fouth fleet:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            
            Sorting.ShellSort(ref fleet);
            Console.WriteLine("List of ships after ShellSort:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            
            int[] fifthFleet = new int[10];
            for(int i = 0; i < 10; i++)
                fifthFleet[i] = new Random().Next(10, 99);
            Array.Resize(ref fleet, 50);
            thirdFleet.CopyTo(fleet, 40);
            Console.WriteLine("List of ships after arriving the fifth fleet:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            
            Sorting.ShellSort(ref fleet);
            Console.WriteLine("List of ships after CountingSort:");
            Console.WriteLine($"{String.Join(", ", fleet)}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
        }
    }
}
