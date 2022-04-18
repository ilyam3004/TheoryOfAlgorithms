using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Channels;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable table = new();
            table.Add("23.10.2000", "Name - Cake");
            table.Add("23.5.2000", "Name1 - Cake");
        }
    }
}
