using System;

namespace implementations
{
    public class Stack
    {
        private SingleLinkedListNode<int> _lastItem = null;
        
        public void Push(int value)
        {
            if (_lastItem == null)
                _lastItem = new SingleLinkedListNode<int> {Value = value, Next = null};

            else
            {
                var newItem = new SingleLinkedListNode<int> {Value = value, Next = _lastItem};
                _lastItem = newItem;
            }
            
        }

        public int Pop()
        {
            if(_lastItem == null)
                throw new Exception("Stack is empty");
            
            var lastItem = _lastItem;
            _lastItem = lastItem.Next;
            return lastItem.Value;
        }
    }
}