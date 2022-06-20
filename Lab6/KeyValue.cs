namespace Lab6
{
    public class KeyValue<K, V>
    {
        public K key { get; }
        public V value { get; }

        public KeyValue(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
        public string ToString() => $"{key} - {value}";
    }
}