using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    public class HashTable
    {
        private List<KeyValue<string, string>>[] array;
        private const int DEF_CAPACITY = 5;
        private int capacity;
        private int size;
        public HashTable()
        {
            capacity = DEF_CAPACITY;
            array = new List<KeyValue<string, string>>[capacity];
        }
        public void Add(string key, string value) => AddNode(new KeyValue<string, string>(key, value), GetHash2(key));
        public void ShowAll()
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write($"{i} : ");
                if (array[i] != null && array[i].Count != 0)
                {
                    foreach (KeyValue<string, string> item in array[i])
                        Console.Write($"({item.ToString()}), ");
                }
                Console.WriteLine();
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
            List<KeyValue<string, string>>[] newArray = new List<KeyValue<string, string>>[capacity];
            foreach (List<KeyValue<string, string>> list in array)
            {
                if (list != null)
                {
                    foreach (KeyValue<string, string> item in list)
                    {
                        int index = GetHash2(item.key);
                        if (newArray[index] == null)
                            newArray[index] = new List<KeyValue<string, string>>();
                        newArray[index].Add(item); 
                    }
                }
            }
            array = newArray;
        }
        private void AddNode(KeyValue<string, string> node, int index)
        {
            size++;
            if ((size * 100) / capacity > 90)
            {
                capacity = size * 2;
                Resize();
            }
            if(array[index] == null)
                array[index] = new List<KeyValue<string, string>>();
            array[index].Add(node);
        }
        public string GetValue(string key) => GetNode(key).value;
        
        private int GetHash1(string key) => Math.Abs(key.GetHashCode() % capacity);
        private int GetHash2(string key) => (int) Math.Abs(key.Sum(x => char.GetNumericValue(x))) % capacity;

    }
}