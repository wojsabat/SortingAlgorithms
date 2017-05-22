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

            int i, j;
            int[] tmp = new int[array.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < array.Length; ++i)
                {
                    bool move = (array[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        array[i - j] = array[i];
                    else
                        tmp[j++] = array[i];
                }
                Array.Copy(tmp, 0, array, array.Length - j, j);
            }

            return array as IEnumerable<T>;
        }
    }
}