using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public interface ISorter
    {
        IEnumerable<T> Sort<T>(IEnumerable<T> collection) where T : IComparable<T>;
    }
}