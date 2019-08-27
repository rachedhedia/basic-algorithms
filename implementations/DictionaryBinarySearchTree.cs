using System;
using System.Collections.Generic;

namespace implementations
{
    public class DictionaryBinarySearchTree<TValueType> where TValueType : struct
    {
        BinarySearchTreeKeyValue<TValueType> _content = new BinarySearchTreeKeyValue<TValueType>();
        
        public void AddOrUpdate(string key, TValueType value)
        {
            if(_content.Contains(key))
                _content.Remove(key);
            
            _content.Add(key, value);
        }

        public TValueType? GetValue(string key)
        {
            return _content.GetValue(key);
        }

        public void Remove(string key)
        {
            _content.Remove(key);
        }

        public bool ContainsKey(string key)
        {
            return _content.Contains(key);
        }

        public IEnumerable<Tuple<string, TValueType>> Traverse()
        {
            return _content.Traverse();
        }
    }
}