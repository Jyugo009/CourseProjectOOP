using MyClassLibrary;
using System;

namespace CourseProjectOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var observedList = new ObservedList<int>();

            observedList.ItemAdded += (sender, e) =>
                Console.WriteLine($"Item added: {e.ChangedItem}");

            observedList.ItemInserted += (sender, e) =>
                Console.WriteLine($"Item inserted at index {e.Index}: {e.ChangedItem}");

            observedList.ItemRemoved += (sender, e) =>
                Console.WriteLine($"Item removed from index {e.Index}: {e.ChangedItem}");

            observedList.ListCleared += (sender, e) =>
                Console.WriteLine("All items cleared from list.");

            observedList.Add(1);

            observedList.Insert(0, 2);

            if (observedList.Contains(1))
            {
                observedList.Remove(1);
            }

            observedList.RemoveAt(0);

          
            observedList.Clear();
        }
    }
}
