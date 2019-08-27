using implementations;
using Xunit;

namespace tests
{
    public class HashTableOpenAdressingTest
    {
        [Fact]
        public void Test()
        {
            var hashTable = new HashTableOpenAddressingKeyValue<int>(6);

            hashTable.Add("key1", 2);
            hashTable.Add("key2", 4);
            hashTable.Add("key2", 6);
            
            Assert.Equal(hashTable.Get("key1"), 2);
            Assert.Equal(hashTable.Get("key2"), 4);
            Assert.Equal(hashTable.Get("key3"), null);
            Assert.Equal(hashTable.ContainsKey("key1"), true);
            Assert.Equal(hashTable.ContainsKey("key2"), true);
            Assert.Equal(hashTable.ContainsKey("key3"), false);
        }
    }
}