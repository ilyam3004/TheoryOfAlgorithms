using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    class Program
    {
        static Random r = new();
        static SmoothSort s = new();
        public static void Main(string[] args)
        {
            int size = 1000;

            List<int[]> fleet = new();
            int armadasAmount = 10;
            InitFleet(ref fleet, armadasAmount);
            Console.WriteLine("Fleet with " + armadasAmount + " armadas created. \nFleet description : ");
            ShowFleet(fleet);
            //int[] arr = SmoothSorting(fleet);
            int[] arr = MergeSorting(fleet);
            Console.WriteLine(ArrayToString(arr));
            Console.Write("\nSorted status : ");

            bool sorted = true;
            for (int i = 0; i<arr.Length-1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    sorted = false;
                    break;
                }
            }
            Console.WriteLine(sorted);
            
        }

        static int[] MergeSorting(List<int[]> fleet)
        {
            Console.WriteLine("\nSorting ships inside each armada :");
            MergeSortArmadas(ref fleet);
            Console.WriteLine("Fleet with sorted armadas :");
            ShowFleet(fleet);
            Console.WriteLine("Make fleet ship ordered list :");
            int[] arr = MergeArmadas(fleet);
            return MergeSort.sort(arr);
        }

        static int[] SmoothSorting(List<int[]> fleet)
        {
            Console.WriteLine("\nSorting ships inside each armada :");
            SmoothSortArmadas(ref fleet);
            Console.WriteLine("Fleet with sorted armadas :");
            ShowFleet(fleet);
            Console.WriteLine("Make fleet ship ordered list :");
            int[] arr = MergeArmadas(fleet);
            s.sort(arr);
            return arr;
        }

        static int[] MergeArmadas(List<int[]> fleet)
        {
            int[] arr = fleet[0];
            foreach (int[] armada in fleet)
                arr = arr.Concat(armada).ToArray();
            return arr;
        }

        static void SmoothSortArmadas(ref List<int[]> fleet)
        {
            for (int i = 0; i < fleet.Count; i++)
                s.sort(fleet[i]);
            
        }

        static void MergeSortArmadas(ref List<int[]> fleet)
        {
            for (int i = 0; i < fleet.Count; i++)
                fleet[i] = MergeSort.sort(fleet[i]);
        }

        static void ShowFleet(List<int[]> fleet)
        {
            for (int i = 0; i < fleet.Count; i++)
                Console.WriteLine("#" + (i + 1) + "("+fleet[i].Length+") |  " + ArrayToString(fleet[i]));
        }

        static string ArrayToString(int[] arr)
        {
            string res = "";
            for (int i = 0; i < arr.Length; i++)
                res += arr[i] + "\t";
            return res;
        }

        static void InitFleet(ref List<int[]> fleet, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                fleet.Add(MakeArmada(r.Next(4,10)));
            }
        }

        static int[] MakeArmada(int size)
        {
            int[] armada = new int[size];
            for (int i = 0; i < size; i++) 
                armada[i] = r.Next(20,100);
            return armada;
        }
    }
}
