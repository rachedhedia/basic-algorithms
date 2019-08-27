using implementations;
using Xunit;

namespace tests
{
    public class BinarySearchTreeKeyTest
    {
        [Fact]
        public void Add()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("d");
            binarySearchTree.Add("b");
            binarySearchTree.Add("f");
            binarySearchTree.Add("a");
            binarySearchTree.Add("c");
            binarySearchTree.Add("e");
            binarySearchTree.Add("g");
            binarySearchTree.Remove("e");

            Assert.Equal(true, binarySearchTree.Contains("c"));
            Assert.Equal(false, binarySearchTree.Contains("l"));
            Assert.Equal("a", binarySearchTree.GetMin());
            Assert.Equal("g", binarySearchTree.GetMax());
            Assert.Equal(false, binarySearchTree.Contains("e"));
        }
    }
}