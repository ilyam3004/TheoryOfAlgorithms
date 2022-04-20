namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable table = new();
            table.Add("23.01.2004", "Sergiy - Cake");
            table.Add("20.02.2004", "Demyan - Pancake");
            table.Add("19.03.2004", "Ilya - Apple pie");
            table.Add("15.04.2004", "Ivan - Brownie");
            table.Add("19.07.2004", "Den - Blueberry pie");
            table.Add("13.08.2004", "Igor - Сhocolate bar");
            table.Add("20.05.2004", "Alex - Сake with frosting");
            table.ShowAll();
        }
    }
}
