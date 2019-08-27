using System;

namespace implementations
{
    public class Heap
    {
        public enum HeapType
        {
            Min,
            Max
        };
        
        class Node
        {
            public Node(string value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
            
            public string Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private DynamicArray<int> _content = new DynamicArray<int>();
        private HeapType _heapType;

        public Heap(HeapType heapType)
        {
            _heapType = heapType;
        }
        
        public void Insert(int value)
        {
            _content.PushBack(value);
            BubbleUp();
        }

        private void BubbleUp()
        {
            int? currentElementIndex = _content.Size - 1;
            while (currentElementIndex.HasValue && ElementDominatesParent(currentElementIndex.Value))
            {
                currentElementIndex = SwapWithParent(currentElementIndex.Value);
            }
        }

        private int? SwapWithParent(int currentElementIndex)
        {
            var elementParentIndex = GetParentIndex(currentElementIndex);
            
            if (!elementParentIndex.HasValue)
                return null;

            var elementParentValueBackup = _content.GetAt(elementParentIndex.Value);
            _content.SetAt(elementParentIndex.Value, _content.GetAt(currentElementIndex));
            _content.SetAt(currentElementIndex, elementParentValueBackup);
            
            return elementParentIndex;
        }

        private int? GetParentIndex(int currentElementIndex)
        {
            if (currentElementIndex <= 0)
                return null;
            
            var currentElementPosition = currentElementIndex + 1;
            var parentElementPosition = currentElementPosition % 2 == 0
                ? currentElementPosition / 2
                : (currentElementPosition - 1) / 2;
            return parentElementPosition - 1;
        }

        private bool FirstElementDominatesSecond(int firstElementIndex, int secondElementIndex)
        {
            if (_heapType == HeapType.Min)
            {
                return _content.GetAt(firstElementIndex) < _content.GetAt(secondElementIndex);
            }
            else
            {
                return _content.GetAt(firstElementIndex) > _content.GetAt(secondElementIndex);
            }
        }
        
        private bool ElementDominatesParent(int currentElementIndex)
        {
            var parentElementIndex = GetParentIndex(currentElementIndex);
            
            if (!parentElementIndex.HasValue)
                return false;

            return FirstElementDominatesSecond(currentElementIndex, parentElementIndex.Value);
        }

        public int? ExtractDominant()
        {
            if (_content.Size == 0)
                return null;

            var dominantElement = _content.GetAt(0);
            
            _content.SetAt(0, _content.GetAt(_content.Size - 1));
            _content.RemoveAt(_content.Size - 1);

            Heapify();
            
            return dominantElement;
        }

        private void Heapify()
        {
            int? currentNodeIndex = 0;
            while (currentNodeIndex.HasValue)
            {
                var currentNodeIndexValue = currentNodeIndex.Value;
                currentNodeIndex = null;
                int? toBeSwapedChildrenIndex = null;
                
                for (var childrenIndex = FirstChildrenIndex(currentNodeIndexValue);
                    childrenIndex <= LastChildrenIndex(currentNodeIndexValue);
                    ++childrenIndex)
                {
                    if (childrenIndex > _content.Size - 1) continue;
                    if (!ElementDominatesParent(childrenIndex)) continue;
                    
                    if (!toBeSwapedChildrenIndex.HasValue)
                        toBeSwapedChildrenIndex = childrenIndex;
                    else
                    {
                        if (FirstElementDominatesSecond(childrenIndex, toBeSwapedChildrenIndex.Value))
                            toBeSwapedChildrenIndex = childrenIndex;
                    }
                }

                if (toBeSwapedChildrenIndex.HasValue)
                {
                    SwapWithParent(toBeSwapedChildrenIndex.Value);
                    currentNodeIndex = toBeSwapedChildrenIndex.Value;
                }
            }
        }

        private int FirstChildrenIndex(int currentNodeIndex)
        {
            var currentNodePosition = currentNodeIndex + 1;
            var firstChildrenPosition = currentNodePosition * 2;
            return firstChildrenPosition - 1;
        }

        private int LastChildrenIndex(int currentNodeIndex)
        {
            var currentNodePosition = currentNodeIndex + 1;
            var lastChildrenPosition = (currentNodePosition * 2) + 1;
            return lastChildrenPosition - 1;
        }
    }
}