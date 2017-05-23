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
            var temp = new T[array.Length];
            int leftEnd = mid - 1;
            int tempPos = left;
            int numElements = right - left + 1;

            while ((left <= leftEnd) && (mid <= right))
            {
                if (array[left].IsSmallerThan(array[mid]))
                    temp[tempPos++] = array[left++];
                else
                    temp[tempPos++] = array[mid++];
            }

            while (left <= leftEnd)
                temp[tempPos++] = array[left++];

            while (mid <= right)
                temp[tempPos++] = array[mid++];

            for (int i = 0; i < numElements; i++)
            {
                array[right] = temp[right];
                right--;
            }
        }
    }
}