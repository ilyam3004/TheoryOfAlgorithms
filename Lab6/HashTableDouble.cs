using System;
using System.Linq;

namespace Lab6
{
    public class HashTableDouble
    {
        private KeyValue<string, string>[] table;
        private const int DEF_CAPACITY = 5;
        private int capacity;
        private int size;
        private int k;
        public HashTableDouble()
        {
            capacity = DEF_CAPACITY;
            table = new KeyValue<string, string>[capacity];
        }
        public void Add(string key, string value) => AddNode(new KeyValue<string, string>(key, value), GetHash(key));
        public void ShowAll()
        {
            for(int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                    Console.Write($"{i} - ({table[i].ToString()}), ");
                else
                    Console.Write($"{i} - ()");
                Console.WriteLine();
            }
        }
        public bool Remove(string key)
        {
            int index = GetHash(key);
            if (table[index] == null)
            {
                Console.WriteLine("Element is already removed!");
                return false;
            }
            table[index] = null;
            return true;
        }
        private KeyValue<string, string> GetNode(string key)
        {
            int index = GetHash(key);
            while(table[index] != null)
            {
                if (table[index].key == key)
                    return table[index];
                if (index + k < capacity)
                    index += k;
                else
                    index = (index + k) % capacity;
            }
            return null;
        }
        public void Resize()
        {
            KeyValue<string, string>[] oldTable = new KeyValue<string, string>[table.Length];
            oldTable = table;
            table = new KeyValue<string, string>[capacity];
            foreach (KeyValue<string, string> item in oldTable)
            {
                if (item != null)
                    AddNode(item, GetHash(item.key));
            }
        }
        private void AddNode(KeyValue<string, string> node, int adress)
        {
            size++;
            k = HashInterval(node.key);
            if((size * 100) / capacity > 90)
            {
                capacity = 6 * (int) Math.Round(Convert.ToDouble(capacity) / 3, 0) - 1;
                Resize();
            }
            while(table[adress] != null)
            {
                if (adress + k < capacity)
                    adress += k;
                else
                    adress = (adress + k) % capacity;
            }
            table[adress] = node;
        }

        public int HashInterval(string key) => GetHash(key);

        public string GetValue(string key) => GetNode(key).value;
        private int GetHash(string key) => (int) Math.Abs(key.Sum(x => char.GetNumericValue(x))) % capacity;
    }
}