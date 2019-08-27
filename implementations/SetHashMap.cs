using System.Collections.Generic;
using System.Linq;

namespace implementations
{
    public class SetHashMap
    {
        private readonly HashTableChainingKey _content = new HashTableChainingKey();
        
        public void Add(string key)
        {
            _content.Add(key);
        }

        public void Remove(string key)
        {
            _content.Remove(key);
        }

        public bool Contains(string key)
        {
            return _content.ContainsKey(key);
        }

        public IEnumerable<string> Content()
        {
            return _content.Traverse();
        }
    }
}