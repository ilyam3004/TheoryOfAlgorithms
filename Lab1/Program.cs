using System;
using System.IO;

namespace Lab1
{
    class Program
    {
        static int[,] array;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose the command:\n" +
                                  "1.Random numbers\n" +
                                  "2.Enter numbers from keyboards\n" +
                                  "3.Read numbers from file");
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
            Console.WriteLine("-------------------------\n" + "Enter count of columns:");
            int columns = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------\n" + "Enter count of rows:");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------\n" + "Enter range of numbers\nFrom:");
            int from = int.Parse(Console.ReadLine());
            Console.WriteLine("To:");
            int to = int.Parse(Console.ReadLine());
            array = new int[rows, columns];
            int max = array[0, 0];
            Random rnd = new();
            Console.WriteLine("-------------------------\n" + "Array:"); 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                { 
                    array[i, j] = rnd.Next(from, to);
                    Console.Write(array[i,j] + " ");
                    if (array[i, j] > max)
                        max = array[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------\n" +
                              "Max element: " + max + "\n" +
                              "--------------------\n");
        }
        static void ReadFromFile()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\ilyam\Desktop\Навчання\TheoryOfAlgorithms\Lab1\input\input.txt");
            array = new int[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    array[i, j] = int.Parse(temp[j]);
                }
            }
            int max = array[0, 0];
            using (StreamWriter sw = new StreamWriter(@"C:\Users\ilyam\Desktop\Навчання\TheoryOfAlgorithms\Lab1\output\output.txt", true, System.Text.Encoding.Default))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[0].Split(' ').Length; j++)
                    {
                        if(array[i, j] > max)
                            max = array[i, j];
                        sw.Write(array[i, j] + " ");
                    }
                    sw.WriteLine();
                }
                sw.WriteLine("Max element of this array: " + max);
                sw.WriteLine("----------------------------");
            }
            Console.WriteLine("--------------------------------------------\n" +
                              "All output data located in file \"output.txt\"\n" +
                              "--------------------------------------------\n");
        }
        static void EnterFromKeyboard()
        {
            Console.WriteLine("-------------------------\n" +
                              "Enter count of columns:");
            int columns = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------\n" +
                              "Enter count of rows:");
            int rows = int.Parse(Console.ReadLine());
            array = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine("Enter the [" + i + ";" + j + "] element of array:");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
            int max = array[0, 0];
            Console.WriteLine("You entered this array:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j] + " ");
                    if (array[i, j] > max)
                        max = array[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------\n" +
                              "Max element: " + max + "\n" +
                              "--------------------\n");
        }
    }
}