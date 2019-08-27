using implementations;
using Xunit;

namespace tests
{
    public class BinarySearchTreeTest
    {
        [Fact]
        public void Add()
        {
            var binarySearchTree = new BinarySearchTreeKeyValue<int>();
            binarySearchTree.Add("d", 4);
            binarySearchTree.Add("b", 2);
            binarySearchTree.Add("f", 6);
            binarySearchTree.Add("a", 1);
            binarySearchTree.Add("c", 3);
            binarySearchTree.Add("e", 5);
            binarySearchTree.Add("g", 7);
            binarySearchTree.Remove("e");

            Assert.Equal(true, binarySearchTree.Contains("c"));
            Assert.Equal(false, binarySearchTree.Contains("l"));
            Assert.Equal("a", binarySearchTree.GetMin().Item1);
            Assert.Equal("g", binarySearchTree.GetMax().Item1);
            Assert.Equal(false, binarySearchTree.Contains("e"));
        }
    }
}