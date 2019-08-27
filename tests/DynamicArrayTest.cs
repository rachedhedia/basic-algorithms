using implementations;
using Xunit;

namespace tests
{
    public class DynamicArrayTest
    {
        [Fact]
        public void PushBackTest()
        {
            var emptyDynamicArray = new DynamicArray<int>();
            var singleElementArray = new DynamicArray<int>();
            var removeAtArray = new DynamicArray<int>();
            var insertAtArray = new DynamicArray<int>();
            
            singleElementArray.PushBack(2);
            removeAtArray.PushBack(1);
            removeAtArray.PushBack(2);
            removeAtArray.PushBack(3);
            removeAtArray.RemoveAt(1);

            insertAtArray.PushBack(1);
            insertAtArray.PushBack(3);
            insertAtArray.AddAt(1, 2);


            Assert.Equal(0, emptyDynamicArray.Size);
            Assert.Equal(1, singleElementArray.Size);
            Assert.Equal(singleElementArray.GetAt(0), 2);
            Assert.Equal(removeAtArray.GetAt(1), 3);
            Assert.Equal(insertAtArray.GetAt(1), 2);
        }
    }
}