using System.Collections.Generic;

namespace implementations
{
    public class DoubleLinkedList
    {
        public class DoubleLinkedListNode
        {
            public DoubleLinkedListNode()
            {
                Value = 0;
                Prev = null;
                Next = null;
            }
            
            public int Value { get; set; }
            public DoubleLinkedListNode Prev { get; set; }
            public DoubleLinkedListNode Next { get; set; }
        }
        
        public static DoubleLinkedListNode Insert(DoubleLinkedListNode doubleLinkedListNode, int value)
        {
            var newNode = new DoubleLinkedListNode {Value = value, Prev = doubleLinkedListNode, Next = doubleLinkedListNode.Next};
            if(doubleLinkedListNode.Next != null)
                doubleLinkedListNode.Next.Prev = newNode;
            doubleLinkedListNode.Next = newNode;
            return newNode;
        }

        public static void RemoveAfter(DoubleLinkedListNode doubleLinkedListNode)
        {
            if (doubleLinkedListNode.Next != null)
                doubleLinkedListNode.Next = doubleLinkedListNode.Next.Next;
        }

        public static void RemoveAt(DoubleLinkedListNode doubleLinkedListNode)
        {
            if (doubleLinkedListNode.Prev != null)
                doubleLinkedListNode.Prev.Next = doubleLinkedListNode.Next;
            if (doubleLinkedListNode.Next != null)
                doubleLinkedListNode.Next.Prev = doubleLinkedListNode.Prev;
        }

        public static DoubleLinkedListNode SearchNodeForward(DoubleLinkedListNode doubleLinkedListNode, int value)
        {
            return doubleLinkedListNode.Value == value ? doubleLinkedListNode : (doubleLinkedListNode.Next != null ? SearchNodeForward(doubleLinkedListNode.Next, value) : null);
        }
        
        public static DoubleLinkedListNode SearchNodeBackward(DoubleLinkedListNode doubleLinkedListNode, int value)
        {
            return doubleLinkedListNode.Value == value ? doubleLinkedListNode : (doubleLinkedListNode.Prev != null ? SearchNodeBackward(doubleLinkedListNode.Prev, value) : null);
        }

        public static IEnumerable<DoubleLinkedListNode> TraverseForward(DoubleLinkedListNode doubleLinkedListNode)
        {
            while (doubleLinkedListNode != null)
            {
                yield return doubleLinkedListNode;
                doubleLinkedListNode = doubleLinkedListNode.Next;
            }
        }

        public static IEnumerable<DoubleLinkedListNode> TraverseBackward(DoubleLinkedListNode doubleLinkedListNode)
        {
            while (doubleLinkedListNode != null)
            {
                yield return doubleLinkedListNode;
                doubleLinkedListNode = doubleLinkedListNode.Prev;
            }
        }
    }
}