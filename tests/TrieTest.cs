using implementations;
using Xunit;

namespace tests
{
    public class TrieTest
    {
        [Fact]
        public void Test()
        {
            var trie = new Trie();
            var prefixTrie = new Trie();
            
            trie.AddWord("the");
            trie.AddWord("their");
            trie.AddWord("there");
            
            prefixTrie.AddWord("h");
            prefixTrie.AddWord("he");
            prefixTrie.AddWord("hel");
            prefixTrie.AddWord("hell");
            prefixTrie.AddWord("hello");
            
            Assert.Equal(new[]{"their"}, trie.GetWordsMatchingPrefix("thei"));
            Assert.Equal(new[]{"the", "their", "there"}, trie.GetWordsMatchingPrefix("the"));
            
            Assert.Equal("hel", prefixTrie.GetLongestMatchingString("helicopter"));
            Assert.Equal("he", prefixTrie.GetLongestMatchingString("he"));
            Assert.Equal("", prefixTrie.GetLongestMatchingString("allo"));
        }
    }
}