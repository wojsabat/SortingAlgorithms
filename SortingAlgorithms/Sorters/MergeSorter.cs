using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Sorters
{
    public class MergeSorter : ISorter
    {
        public  IEnumerable<T> Sort<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            var array = collection.ToArray();
            MergeSort(array, 0, array.Length - 1);
            return array;
        }

        private void MergeSort<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            if (left >= right) return;
            int mid = (left + right) / 2;
            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);
            Merge(array, left, mid+1, right);
        }

        private void Merge<T>(T[] array, int left, int mid, int right) where T : IComparable<T>
        {
            var tempArray = new T[right - left + 1];
            var leftEnd = mid - 1;
            var pointer = 0;
            
            while ((left <= leftEnd) && (mid <= right))
            {
                if (array[left].IsSmallerThan(array[mid]))
                    tempArray[pointer++] = array[left++];
                else
                    tempArray[pointer++] = array[mid++];
            }

            while (left <= leftEnd)
                tempArray[pointer++] = array[left++];

            while (mid <= right)
                tempArray[pointer++] = array[mid++];

            for (int i = tempArray.Length-1; i >=0; i--)
            {
                array[right--] = tempArray[i];
            }
        }
    }
}