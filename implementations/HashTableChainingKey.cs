using System;
using System.Collections.Generic;
using System.Linq;

namespace implementations
{
    public class HashTableChainingKey
    {
        private const int NumberOfBuckets = 29;
        private readonly SingleLinkedListNode<string>[] _buckets = new SingleLinkedListNode<string>[NumberOfBuckets];
        
        public void Add(string key)
        {
            if (ContainsKey(key))
                return;
            var bucketIndex = Hash(key);
            if(_buckets[bucketIndex] == null)
                _buckets[bucketIndex] = new SingleLinkedListNode<string> {Value = key, Next = null};
            else
            {
                SingleLinkedList.Insert(_buckets[bucketIndex], key);
            }
        }

        public void Remove(string key)
        {
            if (!ContainsKey(key))
                return;
            var bucketIndex = Hash(key);
            _buckets[bucketIndex] = Remove(_buckets[bucketIndex], key);
        }

        private SingleLinkedListNode<string> Remove(SingleLinkedListNode<string> rootNode, string key)
        {
            SingleLinkedListNode<string> prevNode = null;
            var currentNode = rootNode;
            
            while (currentNode != null)
            {
                if (currentNode.Value == key)
                {
                    if (prevNode != null)
                    {
                        SingleLinkedList.RemoveAfter(prevNode);
                        return prevNode;
                    }
                    else
                    {
                        return currentNode.Next;
                    }
                }
                    
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }

            return rootNode;
        }

        private int Hash(string key)
        {
            var hash = 0;

            foreach (var character in key)
                hash += GetCharacterValue(character);

            return hash % NumberOfBuckets;
        }

        private int GetCharacterValue(char character)
        {
            return character % 26;
        }

        public bool ContainsKey(string key)
        {
            var bucketIndex = Hash(key);
            var bucket = _buckets[bucketIndex];
            if (bucket == null) return false;
            return SingleLinkedList.Content(bucket).Count(x => x == key) > 0;
        }

        public IEnumerable<string> Traverse()
        {
            foreach (var bucket in _buckets)
            {
                foreach (var entry in SingleLinkedList.Content(bucket))
                {
                    yield return entry;
                }
            }
        }
    }
}