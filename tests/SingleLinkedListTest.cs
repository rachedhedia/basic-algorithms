using System;
using implementations;
using Xunit;

using static implementations.SingleLinkedList;

namespace tests
{
    public class SingleLinkedListTest
    {
        [Fact]
        public void Test()
        {
            var multipleNodesList = new SingleLinkedListNode<int> {Value = 1, Next = null};
            var nextNode = Insert(multipleNodesList, 2);
            Insert(nextNode, 3);
            
            var multipleNodesListToBeReversed = new SingleLinkedListNode<int> {Value = 1, Next = null};
            nextNode = Insert(multipleNodesListToBeReversed, 2);
            Insert(nextNode, 3);

            var withRemovedNodesList = new SingleLinkedListNode<int> {Value = 1, Next = null};
            nextNode = Insert(withRemovedNodesList, 2);
            Insert(nextNode, 3);
            RemoveAfter(withRemovedNodesList);
            
            Assert.Equal(new[]{1, 2, 3}, Content(multipleNodesList));
            Assert.Equal(new[]{3, 2, 1}, Content(Reverse(multipleNodesList)));
            Assert.Equal(new[]{3, 2, 1}, Content(ReverseInPlace(multipleNodesListToBeReversed)));
            Assert.Equal(new[]{1, 3}, Content(withRemovedNodesList));
        }
    }
}