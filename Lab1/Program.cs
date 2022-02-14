using System;
using System.Diagnostics;
using System.IO;

namespace Lab1
{
    class Program
    {
        static int[,] array;

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose the command:\n" +
                                  "1.Random numbers\n" +
                                  "2.Enter numbers from keyboards\n" +
                                  "3.Read numbers from file\n" +
                                  "4.Exit");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        RandomNumbers();
                        break;
                    case "2":
                        EnterFromKeyboard();
                        break;
                    case "3":
                        ReadFromFile();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong command:( Please, try Again\n" +
                                          "-------------------------------- "); 
                        break;
                }
            }
        }
        //------------- Random entering array -------------
        static void RandomNumbers()
        {
            //Start input data
            Console.WriteLine("-------------------------\n" + "Enter count of columns:");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------\n" + "Enter count of rows:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------\n" + "Enter range of numbers\nFrom:");
            int from = int.Parse(Console.ReadLine());
            Console.WriteLine("To:");
            int to = int.Parse(Console.ReadLine());
            array = new int[n, m];
            int min = array[0, 0];
            string index = "";
            Random rnd = new();
            //Entering random numbers in array
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = rnd.Next(from, to);
                }
            }
            //Cheking time
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            //Main code for searching min element
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if(array[i, j] < min)
                    {
                        min = array[i, j];
                        index = "[" + i + "," + j + "]";
                    }
                }
            }
            stopWatch.Stop();
            Console.WriteLine("--------------------\n" +
                              "Min element: " + min + "\n" +
                              "Index of min element: " + index + "\n" + 
                              "Time spent: " + stopWatch.ElapsedMilliseconds + " ms\n" +
                              "--------------------\n");
            using (StreamWriter sw = new StreamWriter(@"C:\Users\ilyam\Desktop\Навчання\TheoryOfAlgorithms\Lab1\output\output.txt", true, System.Text.Encoding.Default))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        sw.Write(array[i, j] + " ");
                    }
                    sw.WriteLine();
                }
                sw.WriteLine("Min element of this array: " + min + "\n" +
                             "Index of min element: " + index + "\n" +
                             "Time spent: " + stopWatch.ElapsedMilliseconds + " ms");
                sw.WriteLine("----------------------------");
            }
        }
        //------------- Reading array from file and writing output data in file -------------
        static void ReadFromFile()
        {
            //Input data processing
            string[] lines = File.ReadAllLines(@"C:\Users\ilyam\Desktop\Навчання\TheoryOfAlgorithms\Lab1\input\input.txt");
            array = new int[lines.Length, lines[0].Split().Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split();
                for (int j = 0; j < temp.Length; j++)
                {
                    array[i, j] = int.Parse(temp[j]);
                }
            }
            int min = array[0, 0];
            string index = "[0,0]";
            //Cheking time of data processing
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Split().Length; j++)
                {
                    if(array[i, j] < min)
                    {
                        min = array[i, j];
                        index = "[" + i + "," + j + "]";
                    }
                }
            }
            stopWatch.Stop();
            using (StreamWriter sw = new StreamWriter(@"C:\Users\ilyam\Desktop\Навчання\TheoryOfAlgorithms\Lab1\output\output.txt", true, System.Text.Encoding.Default))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[0].Split().Length; j++)
                    {
                        sw.Write(array[i, j] + " ");
                    }
                    sw.WriteLine();
                }
                sw.WriteLine("Min element of this array: " + min + "\n" +
                             "Index of min element: " + index + "\n" +
                             "Time spent: " + stopWatch.ElapsedMilliseconds + " ms");
                sw.WriteLine("----------------------------");
            }
            Console.WriteLine("--------------------------------------------\n" +
                              "All output data located in file \"output.txt\"\n" +
                              "--------------------------------------------\n");
        }
        //------------- Entering array from keyboard -------------
        static void EnterFromKeyboard()
        {
            Console.WriteLine("-------------------------\n" + "Enter count of columns:");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------\n" + "Enter count of rows:");
            int n = int.Parse(Console.ReadLine());
            array = new int[n, m];
            string index = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Enter the [" + i + ";" + j + "] element of array:");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
            int min = array[0, 0];
            Console.WriteLine("Array:");
            PrintArray(array, m, n);
            //Cheking time
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        index = "[" + i + "," + j + "]";
                    }
                }
                
            }
            stopWatch.Stop();
            Console.WriteLine("--------------------\n" +
                              "Min element: " + min + "\n" +
                              "Index of min element: " + index + "\n" + 
                              "Time spent: " + stopWatch.ElapsedMilliseconds + " ms\n" +
                              "--------------------\n");
            using (StreamWriter sw = new StreamWriter(@"C:\Users\ilyam\Desktop\Навчання\TheoryOfAlgorithms\Lab1\output\output.txt", true, System.Text.Encoding.Default))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        sw.Write(array[i, j] + " ");
                    }
                    sw.WriteLine();
                }

                sw.WriteLine("Min element of this array: " + min + "\n" +
                             "Index of min element: " + index + "\n" +
                             "Time spent: " + stopWatch.ElapsedMilliseconds + " ms");
                sw.WriteLine("----------------------------");
            }
        }
        public static void PrintArray(int[,] array, int m, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}