namespace implementations
{
    public class HashTableOpenAddressingKeyValue<TValueType> where TValueType : struct
    {
        private class Entry
        {
            public string Key { get; set; }
            public TValueType Value { get; set; }
        }
        
        private readonly Entry[] _content;
        
        public HashTableOpenAddressingKeyValue(int maxSize)
        {
            _content = new Entry[maxSize];
        }

        private int? FindCellIndex(string key)
        {
            var originalHash = Hash(key);
            var cellIndex = originalHash;
            
            if (_content[cellIndex] == null || _content[cellIndex].Key == key)
            {
                return cellIndex;
            }

            cellIndex = originalHash + 1;
                
            if (cellIndex > _content.Length - 1)
            {
                cellIndex = 0;
            }
                
            while (_content[cellIndex] != null && _content[cellIndex].Key != key && cellIndex != originalHash)
            {
                ++cellIndex;
                if (cellIndex > _content.Length - 1)
                {
                    cellIndex = 0;
                }
            }
                
            if (cellIndex == originalHash)
                return null;

            return _content[cellIndex] == null || _content[cellIndex].Key == key ? cellIndex : (int?)null;
        }

        public void Add(string key, TValueType value)
        {
            if (ContainsKey(key))
                return;
            
            var cellIndex = FindCellIndex(key);
            if (cellIndex.HasValue)
            {
                _content[cellIndex.Value] = new Entry{Key = key, Value = value};
            }
        }

        private int Hash(string key)
        {
            var hash = 0;
            
            foreach (var character in key)
                hash += GetCharacterValue(character);
            
            return hash % _content.Length;
        }

        private int GetCharacterValue(char character)
        {
            return character % 26;
        }

        public bool ContainsKey(string key)
        {
            var cellIndex = FindCellIndex(key);
            return cellIndex.HasValue && _content[cellIndex.Value] != null;
        }

        public TValueType? Get(string key)
        {
            var cellIndex = FindCellIndex(key);
            return cellIndex.HasValue ? _content[cellIndex.Value]?.Value : null;
        }
        
    }
}