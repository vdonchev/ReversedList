namespace ReversedList
{
    using System;
    using System.Linq;

    public static class ReversedListTest
    {
        public static void Main()
        {
            IReversedList<int> reversedList = new ReversedList<int>(1);

            reversedList.Add(5);
            reversedList.Add(4);
            reversedList.Add(3);
            reversedList.Add(2);
            reversedList.Add(1);

            Console.WriteLine("List capacity: " + reversedList.Capacity);
            Console.WriteLine("Elements count: " + reversedList.Count);
            reversedList.Remove(4);

            Console.WriteLine(reversedList);
            Console.WriteLine("List capacity: " + reversedList.Capacity);
            Console.WriteLine("Elements count: " + reversedList.Count);

            foreach (var item in reversedList)
            {
                Console.WriteLine("item: " + item);
            }

            Console.WriteLine("Item at index 0: " + reversedList[0]);

            reversedList[0] = 69;
            Console.WriteLine("Item at index 0: " + reversedList[0]);
            
            try
            {
                reversedList[500] = 569;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                var invalidList = new ReversedList<string>(-5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                reversedList.Remove(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            var bigReversedList = new ReversedList<int>();

            for (int i = 0; i < 10000; i++)
            {
                bigReversedList.Add(i);
            }

            Console.WriteLine(string.Join(", ", bigReversedList.Take(10)));
        }
    }
}