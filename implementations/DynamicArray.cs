using System;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace implementations
{
    public class DynamicArray<TValueType>
    {
        private TValueType [] _content = new TValueType[1];
        private int _size = 0;

        public int Size => _size;
            
        public void PushBack(TValueType value)
        {
            if (_size + 1 > _content.Length)
                ExtendCapacity();

            _content[_size] = value;
            _size++;
        }

        private void ExtendCapacity(int minSize = -1)
        {
            var newContent = new TValueType[ComputeNewLength(minSize)];
            for (var i = 0; i < _content.Length; ++i)
            {
                newContent[i] = _content[i];
            }

            _content = newContent;
        }

        private int ComputeNewLength(int minSize)
        {
            if (minSize > _content.Length)
                return minSize;

            return _content.Length * 2;
        }

        public void AddAt(int insertIndex, TValueType value)
        {
            var firstPart = _content.TakeWhile((val, index) => index < insertIndex).Select(i => i).ToArray();
            var secondPart = _content.SkipWhile((val, index) => index < insertIndex).Select(i => i).ToArray();
            
            if(_size + 1 > _content.Length || insertIndex > _content.Length)
                ExtendCapacity(insertIndex + 1);

            for (var i = 0; i < firstPart.Length; ++i)
                _content[i] = firstPart[i];
            _content[insertIndex] = value;
            for (var i = 0; i < secondPart.Length; ++i)
                _content[insertIndex + 1 + i] = secondPart[i];
        }

        public void SetAt(int insertIndex, TValueType value)
        {
            if(insertIndex > _content.Length)
                ExtendCapacity(insertIndex + 1);

            _content[insertIndex] = value;
        }

        public void RemoveAt(int removeIndex)
        {
            if (removeIndex > Size - 1)
                return;
            
            var filteredContent = _content.Where((val, index) => index != removeIndex).Select(i => i).ToArray();
            _content = filteredContent;
            --_size;
        }

        public TValueType GetAt(int index)
        {
            if(index >= _size)
                throw new Exception("Index out of range");
            
            return _content[index];
        }
    }
}