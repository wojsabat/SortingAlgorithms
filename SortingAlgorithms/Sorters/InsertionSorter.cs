using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Sorters
{
    public class InsertionSorter : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            var array = collection.ToArray();
            if (array.Length < 1) return new T[0];
            {
                InsertionSort(array);
            }
            return array;
        }

        private void InsertionSort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (array[j-1].IsBiggerThan(array[j]))
                    {
                        Swap(array,j-1,j);
                    }
                    j--;
                }
            }
        }

        private void Swap<T>(T[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

    }
}