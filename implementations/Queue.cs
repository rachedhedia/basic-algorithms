using System;

namespace implementations
{
    public class Queue<ValueType>
    {
        private SingleLinkedListNode<ValueType> _tail = null;
        private SingleLinkedListNode<ValueType> _head = null;
        public void Enqueue(ValueType value)
        {
            if (_tail == null)
            {
                _tail = new SingleLinkedListNode<ValueType> {Value = value, Next = null};
                _head = _tail;
            }
            else
            {
                _tail.Next = new SingleLinkedListNode<ValueType> {Value = value, Next = null};
                _tail = _tail.Next;
            }
        }

        public ValueType Dequeue()
        {
            if(_head == null)
                throw new Exception("Queue is empty");

            var returnValue = _head.Value;
            _head = _head.Next;
            
            if (_head == null)
                _tail = null;
            

            return returnValue;
        }

        public bool Empty()
        {
            return _head == null;
        }
    }
}