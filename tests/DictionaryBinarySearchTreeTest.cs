using implementations;
using Xunit;

namespace tests
{
    public class DictionaryBinarySearchTreeTest
    {
        [Fact]
        public void Test()
        {
            var dictionary = new DictionaryBinarySearchTree<int>();
            dictionary.AddOrUpdate("d", 4);
            dictionary.AddOrUpdate("b", 2);
            dictionary.AddOrUpdate("f", 6);
            dictionary.AddOrUpdate("a", 1);
            dictionary.AddOrUpdate("c", 3);
            dictionary.AddOrUpdate("e", 5);
            dictionary.AddOrUpdate("g", 7);
            dictionary.AddOrUpdate("d", 15);
            dictionary.Remove("e");

            Assert.Equal(true, dictionary.ContainsKey("c"));
            Assert.Equal(false, dictionary.ContainsKey("l"));
            Assert.Equal(1, dictionary.GetValue("a"));
            Assert.Equal(15, dictionary.GetValue("d"));
            Assert.Equal(false, dictionary.ContainsKey("e"));
        }
    }
}