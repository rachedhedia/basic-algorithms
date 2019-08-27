using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;

namespace implementations
{
    public class Trie
    {
        class TrieNode
        {
            public TrieNode(char value)
            {
                Value = value;
                Nodes = new Dictionary<char, TrieNode>();
                WordLastCharacter = false;
            }
            public char Value { get; set; }
            public Dictionary<char, TrieNode> Nodes { get; set; }
            public bool WordLastCharacter { get; set; }
        }
        
        private TrieNode _root = new TrieNode(' ');
        
        public void AddWord(string word)
        {
            var availableChars = _root.Nodes;
            TrieNode wordLastCharacterNode = null;

            foreach (var currentCharacter in word)
            {
                if (!availableChars.ContainsKey(currentCharacter))
                    availableChars.Add(currentCharacter, new TrieNode(currentCharacter));

                wordLastCharacterNode = availableChars[currentCharacter];
                availableChars = availableChars[currentCharacter].Nodes;
            }

            wordLastCharacterNode.WordLastCharacter = true;
        }

        public IEnumerable<string> GetWordsMatchingPrefix(string prefix)
        {
            return _root.Nodes.SelectMany(x => GetWordsMatchingPrefix(x.Value, prefix, ""));
        }

        private IEnumerable<string> GetWordsMatchingPrefix(TrieNode node, string prefix, string content)
        {
            if (prefix.Any())
            {
                if (prefix.First() != node.Value)
                    yield break;

                prefix = prefix.Substring(1);
            }

            if (node.WordLastCharacter)
            {
                if (prefix == "")
                    yield return content + node.Value;
            }

            if (!node.Nodes.Any())
            {
                yield break;
            }
            
            foreach (var entry in node.Nodes.SelectMany(x =>
                GetWordsMatchingPrefix(x.Value, prefix, content + node.Value)))
            {
                yield return entry;
            }
        }

        public string GetLongestMatchingString(string stringToMatch)
        {
            var childNode = _root.Nodes.
                Where(x => x.Value.Value == stringToMatch[0]).
                Select(x => x.Value).
                FirstOrDefault();
            
            return childNode != null ? GetLongestMatchingString(childNode, stringToMatch) : "";
        }

        private string GetLongestMatchingString(TrieNode node, string stringToMatch)
        {
            if (!stringToMatch.Any())
                return "";
           
            if (node.Value != stringToMatch[0])
                return "";


            var subContent = node.Nodes.Select(x => GetLongestMatchingString(x.Value, stringToMatch.Substring(1)));
            return node.Value + (subContent.OrderByDescending(x => x.Length).FirstOrDefault() ?? "");
        }
    }
}