using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Sorters
{
    public class BubbleSorter : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            var array = collection.ToArray();

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    if (array[j - 1].IsBiggerThan(array[j]))
                    {
                        Swap(array, j, j-1);
                    }
                }
            }

            return array;
        }

        private void Swap<T>(T[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}