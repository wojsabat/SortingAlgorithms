using System;
using System.Collections.Generic;
using System.Diagnostics;
using SortingAlgorithms.Sorters;

namespace SortingAlgorithms.ConsoleApp
{
    public class SortNumbersTest
    {
        private const int MaxNumber = 500000;
        private static List<int> NumbersOfElements = new List<int> { 10, 100, 1000, 10000, 20000, 30000, 40000, 50000, 70000, 90000, 100000 };
        private static List<ISorter> Sorters = new List<ISorter>
        {
            //new BubbleSorter(),
            //new SelectionSorter(),
            new QuickSorter(),
            new MergeSorter(),
        };

        public static void Run()
        {
            foreach (var numberOfElements in NumbersOfElements)
            {
                var array = GetRandomArray(numberOfElements);
                var stopwatch = new Stopwatch();

                Console.WriteLine($"\nTest for {numberOfElements} elements from 0 to {MaxNumber}:");

                foreach (var sorter in Sorters)
                {
                    stopwatch.Start();
                    var sorted = sorter.Sort(array);
                    stopwatch.Stop();

                    PrintResult(sorter, stopwatch, sorted);
                    stopwatch.Reset();
                }
            }
        }

        private static int[] GetRandomArray(int count)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            var array = new int[count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(MaxNumber + 1);
            }

            return array;
        }

        private static void PrintResult(ISorter sorter, Stopwatch stopwatch, IEnumerable<int> sorted)
        {
            Console.WriteLine($"{sorter.GetType().Name}\t\tElapsed: {stopwatch.Elapsed}");

//            foreach (var number in sorted)
//            {
//                Console.Write($"{number} ");
//            }
//            Console.WriteLine("");
        }
    }
}