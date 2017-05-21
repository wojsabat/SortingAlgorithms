using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SortingAlgorithms.Sorters;

namespace SortingAlgorithms.ConsoleApp
{
    public static class SortFileTest
    {
        private const string Path = @"C:\SortingTests\";
        public static void Run()
        {
            var array = ReadFile();
            var sorter = new QuickSorter();
            var stopwatch = new Stopwatch();

            Console.WriteLine($"Test for {array.Length} elements.");

            stopwatch.Start();
            var result = sorter.Sort(array);
            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
            WritToFile(result.ToArray());
        }

        private static char[] ReadFile()
        {
            using (StreamReader sr = new StreamReader(Path +"TextFile50MB.txt"))
            {
                String text = sr.ReadToEnd();
                return text.ToCharArray();
            }
        }

        private static void WritToFile(char[] elements)
        {
            using (StreamWriter outputFile = new StreamWriter(Path + "Result.txt"))
            {
                var text = new string(elements);
                outputFile.WriteLine(text);
            }
        }
    }
}