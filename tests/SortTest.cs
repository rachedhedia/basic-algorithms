using implementations;
using Xunit;

namespace tests
{
    public class SortTest
    {
        [Fact]
        public void InsertionSortTest()
        {
            Assert.Equal(new []{1, 2, 3, 4, 5, 6}, Sort.InsertionSort(new []{3, 1, 4, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 5, 6, 7}, Sort.InsertionSort(new []{3, 1, 4, 7, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 4, 5, 6}, Sort.InsertionSort(new []{3, 1, 4, 6, 2, 4, 5}));
        }
        
        [Fact]
        public void SelectionSortTest()
        {
            Assert.Equal(new []{1, 2, 3, 4, 5, 6}, Sort.SelectionSort(new []{3, 1, 4, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 5, 6, 7}, Sort.SelectionSort(new []{3, 1, 4, 7, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 4, 5, 6}, Sort.SelectionSort(new []{3, 1, 4, 6, 2, 4, 5}));
        }
        
        [Fact]
        public void BubbleSortTest()
        {
            Assert.Equal(new []{1, 2, 3, 4, 5, 6}, Sort.BubbleSort(new []{3, 1, 4, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 5, 6, 7}, Sort.BubbleSort(new []{3, 1, 4, 7, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 4, 5, 6}, Sort.BubbleSort(new []{3, 1, 4, 6, 2, 4, 5}));
        }
        
        [Fact]
        public void HeapSortTest()
        {
            Assert.Equal(new []{1, 2, 3, 4, 5, 6}, Sort.HeapSort(new []{3, 1, 4, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 5, 6, 7}, Sort.HeapSort(new []{3, 1, 4, 7, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 4, 5, 6}, Sort.HeapSort(new []{3, 1, 4, 6, 2, 4, 5}));
        }

        [Fact]
        public void MergeSortTest()
        {
            Assert.Equal(new []{1, 2, 3, 4, 5, 6}, Sort.MergeSort(new []{3, 1, 4, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 5, 6, 7}, Sort.MergeSort(new []{3, 1, 4, 7, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 4, 5, 6}, Sort.MergeSort(new []{3, 1, 4, 6, 2, 4, 5}));
        }
        
        [Fact]
        public void QuickSortTest()
        {
            Assert.Equal(new []{1, 2, 3, 4, 5, 6}, Sort.QuickSort(new []{3, 1, 4, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 5, 6, 7}, Sort.QuickSort(new []{3, 1, 4, 7, 6, 2, 5}));
            Assert.Equal(new []{1, 2, 3, 4, 4, 5, 6}, Sort.QuickSort(new []{3, 1, 4, 6, 2, 4, 5}));
        }
    }
}