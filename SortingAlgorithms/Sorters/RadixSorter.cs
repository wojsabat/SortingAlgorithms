using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Sorters
{
    public class RadixSorter : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> collection) where T : IComparable<T>
        {
            var array = collection.ToArray() as int[];
            var tempArray = new int[array.Length];
            

            for (int shift = 31; shift >= 0; --shift)
            {
                var j = 0;
                for (int i = 0; i < array.Length; ++i)
                {
                    bool move = (array[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        array[i - j] = array[i];
                    else
                        tempArray[j++] = array[i];
                }
                Array.Copy(tempArray, 0, array, array.Length - j, j);
            }

            return array as IEnumerable<T>;
        }
    }
}