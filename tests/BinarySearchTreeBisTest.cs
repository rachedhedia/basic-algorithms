using System;
using System.Linq;
using implementations;
using Xunit;

namespace tests
{
    public class BinarySearchTreeBisTest
    {
        [Fact]
        public void Add()
        {
            var binarySearchTree = new BinarySearchTreeBis();
            binarySearchTree.Add(4);
            binarySearchTree.Add(2);
            binarySearchTree.Add(6);
            binarySearchTree.Add(1);
            binarySearchTree.Add(3);
            binarySearchTree.Add(5);
            binarySearchTree.Add(7);
            
            //var treeRepresentation = binarySearchTree.GetStringRepresentation();
            //Assert.Equal("4, \n2, 6, \n, 1, 3, 5, 7, \n", treeRepresentation);
            var stringRep = binarySearchTree.TraverseDfsInOrderIterative().Aggregate("", (total, next) => total + " " + next);
            Assert.Equal(" 1 2 3 4 5 6 7", stringRep);
            
            stringRep = binarySearchTree.TraverseDfsInOrderRecursive().Aggregate("", (total, next) => total + " " + next);
            Assert.Equal(" 1 2 3 4 5 6 7", stringRep);
            
            stringRep = binarySearchTree.TraverseDfsPreOrderIterative().Aggregate("", (total, next) => total + " " + next);
            Assert.Equal(" 4 2 1 3 6 5 7", stringRep);
            
            stringRep = binarySearchTree.TraverseDfsPreOrderRecursive().Aggregate("", (total, next) => total + " " + next);
            Assert.Equal(" 4 2 1 3 6 5 7", stringRep);
            
            stringRep = binarySearchTree.TraverseDfsPostOrderIterative().Aggregate("", (total, next) => total + " " + next);
            Assert.Equal(" 1 3 2 5 7 6 4", stringRep);
            
            stringRep = binarySearchTree.TraverseDfsPostOrderRecursive().Aggregate("", (total, next) => total + " " + next);
            Assert.Equal(" 1 3 2 5 7 6 4", stringRep);
            
            stringRep = binarySearchTree.TraverseDfsReverseOrderIterative().Aggregate("", (total, next) => total + " " + next);
            Assert.Equal(" 7 6 5 4 3 2 1", stringRep);
            
            stringRep = binarySearchTree.TraverseDfsReverseOrderRecursive().Aggregate("", (total, next) => total + " " + next);
            Assert.Equal(" 7 6 5 4 3 2 1", stringRep);
        }
    }
}