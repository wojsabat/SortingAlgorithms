using System;

namespace SortingAlgorithms
{
    public static class ComparableExtensions
    {
        public static bool IsBiggerThan<T>(this T source, T value) where T : IComparable<T>
        {
            return source.CompareTo(value) > 0;
        }

        public static bool IsSmallerThan<T>(this T source, T value) where T : IComparable<T>
        {
            return source.CompareTo(value) < 0;
        }
    }
}