using System.Collections.Generic;
using System.Linq;

namespace implementations
{
    public class SetBinarySearchTree
    {
        private readonly BinarySearchTreeKey _content = new BinarySearchTreeKey();
        
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
            return _content.Contains(key);
        }

        public IEnumerable<string> Content()
        {
            return _content.Traverse();
        }
    }
}