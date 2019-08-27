using System;
using System.Collections.Generic;

namespace implementations
{
    public class DictionaryHashTable<TValueType> where TValueType : struct
    {
        HashTableChainingKeyValue<TValueType> _content = new HashTableChainingKeyValue<TValueType>();
        
        public void AddOrUpdate(string key, TValueType value)
        {
            if(_content.ContainsKey(key))
                _content.Remove(key);
            
            _content.Add(key, value);
        }

        public TValueType? GetValue(string key)
        {
            return _content.Get(key);
        }

        public void Remove(string key)
        {
            _content.Remove(key);
        }

        public bool ContainsKey(string key)
        {
            return _content.ContainsKey(key);
        }

        public IEnumerable<Tuple<string, TValueType>> Traverse()
        {
            return _content.Traverse();
        }
    }
}