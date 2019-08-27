using System.Linq;
using implementations;
using Xunit;

using static implementations.DoubleLinkedList;

namespace tests
{
    public class DoubleLinkedListTest
    {

        [Fact]
        public void Test()
        {
            var multipleNodesList = new DoubleLinkedListNode {Value = 1, Next = null};
            var nextNode = Insert(multipleNodesList, 2);
            Insert(nextNode, 3);

            RemoveAt(nextNode);
            
            Assert.Equal(new[]{1, 3}, TraverseForward(multipleNodesList).Select(i => i.Value));
            Assert.Equal(new[]{3, 1}, TraverseBackward(TraverseForward(multipleNodesList).Last()).Select(i => i.Value));
        }
    }
}