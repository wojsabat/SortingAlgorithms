using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Sorters
{
    public class QuickSorter : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            var array = collection.ToArray();
            if(array.Length<1) return new T[0];

            QuickSort(array, 0, array.Length - 1);

            return array;
        }

        private void QuickSort<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            int leftPointer = start;
            int rightPointer = end;
            var pivot = array[(start+end)/2];

            while (leftPointer<=rightPointer)
            {
                while (array[leftPointer].IsSmallerThan(pivot))
                {
                    leftPointer++;
                }
                while (array[rightPointer].IsBiggerThan(pivot))
                {
                    rightPointer--;
                }
                if (leftPointer<=rightPointer)
                {
                    var temp = array[leftPointer];
                    array[leftPointer] = array[rightPointer];
                    array[rightPointer] = temp;

                    leftPointer++;
                    rightPointer--;
                }
            }

            if (start < rightPointer)
            {
                QuickSort(array, start, rightPointer);
            }
            if (end > leftPointer)
            {
                QuickSort(array, leftPointer, end);
            }            
        }
    }
}