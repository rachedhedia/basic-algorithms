using implementations;
using Xunit;

namespace tests
{
    public class HashTableChainingKeyTest
    {
        [Fact]
        public void Test()
        {
            var hashTable = new HashTableChainingKey();

            hashTable.Add("key1");
            hashTable.Add("key2");
            hashTable.Add("key2");
            
            Assert.Equal(hashTable.ContainsKey("key1"), true);
            Assert.Equal(hashTable.ContainsKey("key2"), true);
            Assert.Equal(hashTable.ContainsKey("key3"), false);
        }
    }
}