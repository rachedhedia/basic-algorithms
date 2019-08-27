using System;
using System.Collections.Generic;
using System.Linq;
using static implementations.SingleLinkedList;

namespace implementations
{
    public class HashTableChainingKeyValue<TValueType> where TValueType : struct
    {
        struct Entry
        {
            public string Key { get; set; }
            public TValueType Value { get; set; }
        }
        
        
        private const int NumberOfBuckets = 29;
        private readonly SingleLinkedListNode<Entry>[] _buckets = new SingleLinkedListNode<Entry>[NumberOfBuckets];
        
        public void Add(string key, TValueType value)
        {
            if (ContainsKey(key))
                return;
            var bucketIndex = Hash(key);
            if(_buckets[bucketIndex] == null)
                _buckets[bucketIndex] = new SingleLinkedListNode<Entry> {Value = new Entry{Key = key, Value = value}, Next = null};
            else
            {
                Insert(_buckets[bucketIndex], new Entry{Key = key, Value = value});
            }
        }

        public void Remove(string key)
        {
            if (!ContainsKey(key))
                return;
            var bucketIndex = Hash(key);
            _buckets[bucketIndex] = Remove(_buckets[bucketIndex], key);
        }

        private SingleLinkedListNode<Entry> Remove(SingleLinkedListNode<Entry> rootNode, string key)
        {
            SingleLinkedListNode<Entry> prevNode = null;
            var currentNode = rootNode;
            
            while (currentNode != null)
            {
                if (currentNode.Value.Key == key)
                {
                    if (prevNode != null)
                    {
                        RemoveAfter(prevNode);
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
            return Content(bucket).Count(x => x.Key == key) > 0;
        }

        public TValueType? Get(string key)
        {
            var bucketIndex = Hash(key);
            if (_buckets[bucketIndex] != null)
                return Content(_buckets[bucketIndex]).Count(x => x.Key == key) > 0 ? 
                    Content(_buckets[bucketIndex]).First(x => x.Key == key).Value : (TValueType?)null;
            
            return null;
        }

        public IEnumerable<Tuple<string, TValueType>> Traverse()
        {
            foreach (var bucket in _buckets)
            {
                foreach (var entry in Content(bucket))
                {
                    yield return new Tuple<string, TValueType>(entry.Key, entry.Value);
                }
            }
        }
    }
}