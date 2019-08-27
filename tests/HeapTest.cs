using implementations;
using Xunit;

namespace tests
{
    public class HeapTest
    {
        [Fact]
        public void Test()
        {
            var heapMin = new Heap(Heap.HeapType.Min);
            var heapMax = new Heap(Heap.HeapType.Max);
            
            heapMin.Insert(15);
            heapMin.Insert(2);
            heapMin.Insert(7);
            heapMin.Insert(6);
            heapMin.Insert(27);
            
            heapMax.Insert(15);
            heapMax.Insert(2);
            heapMax.Insert(7);
            heapMax.Insert(6);
            heapMax.Insert(27);
            
            Assert.Equal(2, heapMin.ExtractDominant());
            Assert.Equal(6, heapMin.ExtractDominant());
            Assert.Equal(7, heapMin.ExtractDominant());
            Assert.Equal(15, heapMin.ExtractDominant());
            Assert.Equal(27, heapMin.ExtractDominant());
            
            Assert.Equal(27, heapMax.ExtractDominant());
            Assert.Equal(15, heapMax.ExtractDominant());
            Assert.Equal(7, heapMax.ExtractDominant());
            Assert.Equal(6, heapMax.ExtractDominant());
            Assert.Equal(2, heapMax.ExtractDominant());
        }
    }
}