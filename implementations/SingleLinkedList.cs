using System.Collections.Generic;

namespace implementations
{
    public class SingleLinkedListNode<TValueType>
    {
        public SingleLinkedListNode()
        {
            Next = null;
        }
            
        public TValueType Value { get; set; }
        public SingleLinkedListNode<TValueType> Next { get; set; }
    }
    
    public static class SingleLinkedList
    {
        public static SingleLinkedListNode<T> Insert<T>(SingleLinkedListNode<T> singleLinkedListNode, T value)
        {
            var newNode = new SingleLinkedListNode<T> {Value = value, Next = singleLinkedListNode.Next};
            singleLinkedListNode.Next = newNode;
            return newNode;
        }

        /*public static SingleLinkedListNode<T> Remove<T>(SingleLinkedListNode<T> rootNode, T value) where T : struct
        {
            SingleLinkedListNode<T> prevNode = null;
            var currentNode = rootNode;
            
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    if (prevNode != null)
                    {
                        RemoveAfter(prevNode);
                        return rootNode;
                    }
                    else
                    {
                        return currentNode;
                    }
                }
                    
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }

            return rootNode;
        }*/

        public static void RemoveAfter<T>(SingleLinkedListNode<T> singleLinkedListNode)
        {
            if (singleLinkedListNode.Next != null)
                singleLinkedListNode.Next = singleLinkedListNode.Next.Next;
        }

        public static IEnumerable<T> Content<T>(SingleLinkedListNode<T> singleLinkedListNode)
        {
            while (singleLinkedListNode != null)
            {
                yield return singleLinkedListNode.Value;
                singleLinkedListNode = singleLinkedListNode.Next;
            }
        }

        public static IEnumerable<SingleLinkedListNode<T>> Nodes<T>(SingleLinkedListNode<T> singleLinkedListNode)
        {
            while (singleLinkedListNode != null)
            {
                yield return singleLinkedListNode;
                singleLinkedListNode = singleLinkedListNode.Next;
            }
        }

        public static SingleLinkedListNode<T> Reverse<T>(SingleLinkedListNode<T> root)
        {
            var stack = new Stack<SingleLinkedListNode<T>>();
            foreach(var entry in Nodes(root))
                stack.Push(entry);

            var newRoot = stack.Pop();
            var current = newRoot;

            while (current != null)
            {
                var next = stack.Count > 0 ? stack.Pop() : null;
                current.Next = next;
                current = next;
            }

            return newRoot;
        }

        public static SingleLinkedListNode<T> ReverseInPlace<T>(SingleLinkedListNode<T> root)
        {
            if (root == null || root.Next == null)
                return root;
            
            var currentNode = root;
            var nextNode = root.Next;
            var nextNextNode = nextNode.Next;

            currentNode.Next = null;

            while (nextNode != null)
            {
                nextNode.Next = currentNode;
                currentNode = nextNode;
                nextNode = nextNextNode;
                nextNextNode = nextNode?.Next;
            }

            return currentNode;
        }
    }
}