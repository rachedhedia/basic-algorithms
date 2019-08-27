using System.Linq;
using implementations;
using Xunit;

namespace tests
{
    public class SetBinarySearchTreeTest
    {
        [Fact]
        public void Test()
        {
            var setBinarySearchTree = new SetBinarySearchTree();
            setBinarySearchTree.Add("hello");
            setBinarySearchTree.Add("tutu");
            setBinarySearchTree.Add("toto");
            setBinarySearchTree.Add("toto");
            setBinarySearchTree.Add("hello");
            setBinarySearchTree.Remove("hello");
            
            Assert.Equal(true, setBinarySearchTree.Contains("tutu"));
            Assert.Equal(true, setBinarySearchTree.Contains("toto"));
            Assert.Equal(false, setBinarySearchTree.Contains("hello"));
            Assert.Equal(2, setBinarySearchTree.Content().Count());
        }
    }
}