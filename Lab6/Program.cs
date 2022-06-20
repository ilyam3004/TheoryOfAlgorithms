using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------ HashTable with linear zonding ------------");
            HashTableLinear tableLinear = new();
            tableLinear.Add("23.01.2004", "Sergiy - Cake");
            tableLinear.Add("20.02.2004", "Demyan - Pancake");
            tableLinear.Add("19.03.2004", "Ilya - Apple pie");
            tableLinear.Add("15.04.2004", "Ivan - Brownie");
            tableLinear.Add("19.07.2004", "Den - Blueberry pie");
            tableLinear.Add("13.08.2004", "Igor - Сhocolate bar");
            tableLinear.Add("20.05.2004", "Alex - Сake with frosting");
            tableLinear.ShowAll();
            Console.WriteLine("------------ HashTable with double zonding ------------");
            HashTableDouble tableDouble = new();
            tableDouble.Add("23.01.2004", "Sergiy - Cake");
            tableDouble.Add("20.02.2004", "Demyan - Pancake");
            tableDouble.Add("19.03.2004", "Ilya - Apple pie");
            tableDouble.Add("15.04.2004", "Ivan - Brownie");
            tableDouble.Add("19.07.2004", "Den - Blueberry pie");
            tableDouble.Add("13.08.2004", "Igor - Сhocolate bar");
            tableDouble.Add("20.05.2004", "Alex - Сake with frosting");
            tableDouble.ShowAll();
        }
    }
}
