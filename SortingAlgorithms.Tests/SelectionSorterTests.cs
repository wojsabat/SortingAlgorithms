using System.Linq;
using SortingAlgorithms.Sorters;
using Xunit;

namespace SortingAlgorithms.Tests
{
    public class SelectionSorterTests
    {
        private readonly ISorter _sorter;

        public SelectionSorterTests()
        {
            _sorter = new SelectionSorter();
        }

        [Fact]
        public void Sort_when_array_is_empty_then_returns_empty_array()
        {
            var collection = new int[] { };

            var result = _sorter.Sort(collection);

            Assert.Equal(0, result.Count());
        }

        [Fact]
        public void Sort_when_array_has_one_element_then_returns_the_same_array()
        {
            var collection = new[] { 3 };

            var result = _sorter.Sort(collection);

            Assert.Equal(collection, result);
        }

        [Fact]
        public void Sort_when_array_is_sorted_then_returns_the_same_array()
        {
            var collection = new[] { 2, 5, 8, 12 };

            var result = _sorter.Sort(collection);

            Assert.Equal(collection, result);
        }

        [Fact]
        public void Sort_when_not_sorted_pair_then_swaps_elements()
        {
            var collection = new[] { 2, 1 };

            var result = _sorter.Sort(collection);

            Assert.Equal(new[] { 1, 2 }, result);
        }

        [Fact]
        public void Sort_when_sortable_in_one_iteration_then_sorts_elements()
        {
            var collection = new[] { 1, 6, 5 };

            var result = _sorter.Sort(collection);

            Assert.Equal(new[] { 1, 5, 6 }, result);
        }

        [Fact]
        public void Sort_when_not_sorted_array_then_sorts_elements()
        {
            var collection = new[] { 6, 1, 8, 2, 123, 2, 1, 18, 2000, 100, 2 };

            var result = _sorter.Sort(collection);

            Assert.Equal(new[] { 1, 1, 2, 2, 2, 6, 8, 18, 100, 123, 2000 }, result);
        }


    }
}
