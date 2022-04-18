using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    public class HashTable
    {
        private List<KeyValue<string, string>>[] array;
        private const int DEF_CAPACITY = 10;
        private int capacity;
        private int size;
        public HashTable()
        {
            capacity = DEF_CAPACITY;
            array = new List<KeyValue<string, string>>[capacity];
        }
        public void Add(string key, string value)
        {
            int index = GetHash2(key);
            KeyValue<string, string> node = new KeyValue<string, string>(key, value);
            size++;
            if((size * 100) / capacity > 80)
            {
            }

            if (array[index] == null)
                array[index] = new List<KeyValue<string, string>>();
            array[index].Add(node);
        }
        public void ShowAll()
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i}:");
                if (array[i] != null && array[i].Count != 0)
                {
                    foreach (KeyValue<string, string> item in array[i])
                    {
                        Console.WriteLine($"\t{item.ToString()}");
                    }
                }
            }
        }
        public bool Remove(string key)
        {
            int index = GetHash2(key);
            if (array[index] == null)
                return false;
            return array[index].Remove(GetNode(key));
        }
        private KeyValue<string, string> GetNode(string key)
        {
            int index = GetHash2(key);
            if(array[index] == null)
                throw new Exception($"No value by this key - {key}");
            foreach (KeyValue<string, string> item in array[index])
            {
                if (item.key.Equals(key))
                    return item;
            }
            throw new Exception($"No value by this key - {key}");
        }

        public void Resize()
        {
            List<KeyValue<string, string>> nodes = new();
            foreach (List<KeyValue<string, string>> list in array)
            {
                if (list != null)
                {
                    foreach (KeyValue<string, string> item in list)
                        nodes.Add(item);
                }
            }
            Array.Resize(ref array, size * 2);
            for(int i = 0; i < array.Length; i++)
                array[i] = null;
        }
        public string GetValue(string key) => GetNode(key).value;
        
        private int GetHash1(string key) => Math.Abs(key.GetHashCode() % array.Length);
        private int GetHash2(string key) => (int) Math.Abs(key.Sum(x => char.GetNumericValue(x))) % capacity;

    }
}