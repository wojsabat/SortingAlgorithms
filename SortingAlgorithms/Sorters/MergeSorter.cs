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

            private void MergeSort<T>(T[] array, int startIndex, int endIndex) where T : IComparable<T>
            {
                if (startIndex < endIndex)
                {
                    MergeSort(array, startIndex, (startIndex + endIndex) / 2);
                    MergeSort(array, (startIndex + endIndex) / 2 + 1, endIndex);
                    Merge(array, startIndex, endIndex);
                }
            }

            private void Merge<T>(T[] array, int startIndex, int endIndex) where T : IComparable<T>
            {
                T[] tempArray = new T[array.Length];
                for (int i = startIndex; i <= endIndex; i++)
                {
                    tempArray[i] = array[i];
                }

                int tempStartIndex = startIndex;
                int tempMiddleIndex = (startIndex + endIndex) / 2 + 1;
                int r = startIndex;
                while (tempStartIndex <= (startIndex + endIndex) / 2 && tempMiddleIndex <= endIndex)
                {
                    if (tempArray[tempStartIndex].IsSmallerThan(tempArray[tempMiddleIndex]))
                    {
                        array[r] = tempArray[tempStartIndex];
                        r++;
                        tempStartIndex++;
                    }
                    else
                    {
                        array[r] = tempArray[tempMiddleIndex];
                        r++;
                        tempMiddleIndex++;
                    }
                }

                while (tempStartIndex <= (startIndex + endIndex) / 2)
                {
                    array[r] = tempArray[tempStartIndex];
                    r++;
                    tempStartIndex++;
                }
            }
        }
    }