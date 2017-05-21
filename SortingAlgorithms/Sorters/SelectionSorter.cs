using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Sorters
{
    public class SelectionSorter : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            var array = collection.ToArray();
            T min;
            int minIndex;

            for (int i = 0; i < array.Length; i++)
            {
                min = array[i];
                minIndex = i;

                for (int j = i; j < array.Length; j++)
                {
                    if (array[j].CompareTo(min) < 0)
                    {
                        min = array[j];
                        minIndex = j;
                    }
                }

                array[minIndex] = array[i];
                array[i] = min;
            }

            return array;
        }
    }
}