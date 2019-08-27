using System;
using implementations;
using Xunit;

namespace tests
{
    public class DFSTest
    {
        [Fact]
        public void DFSBinarySearchTreeInOrderRecursiveTest()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");
            
            Assert.Equal(new []{"1", "2", "3", "4", "5", "6", "7"}, DFS.DFSBinarySearchTreeInOrderRecursive(binarySearchTree.Root));
        }
        
        [Fact]
        public void DFSBinarySearchTreeInOrderIterativeTest()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");
            
            Assert.Equal(new []{"1", "2", "3", "4", "5", "6", "7"}, DFS.DFSBinarySearchTreeInOrderIterative(binarySearchTree.Root));
        }
        
        [Fact]
        public void DFSBinarySearchTreePreOrderRecursiveTest()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");
            
            Assert.Equal(new []{"4", "2", "1", "3", "6", "5", "7"}, DFS.DFSBinarySearchTreePreOrderRecursive(binarySearchTree.Root));
        }
        
        [Fact]
        public void DFSBinarySearchTreePreOrderIterativeTest()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");
            
            Assert.Equal(new []{"4", "2", "1", "3", "6", "5", "7"}, DFS.DFSBinarySearchTreePreOrderIterative(binarySearchTree.Root));
        }
        
        [Fact]
        public void DFSBinarySearchTreePostOrderRecursiveTest()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");
            
            Assert.Equal(new []{"1", "3", "2", "5", "7", "6", "4"}, DFS.DFSBinarySearchTreePostOrderRecursive(binarySearchTree.Root));
        }
        
        [Fact]
        public void DFSBinarySearchTreePostOrderIterativeTest()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");
            
            Assert.Equal(new []{"1", "3", "2", "5", "7", "6", "4"}, DFS.DFSBinarySearchTreePostOrderIterative(binarySearchTree.Root));
        }

        [Fact]
        public void DFSGraphEdgeRecursiveTest()
        {
            var undirectedGraphWithCycles = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Undirected);
            undirectedGraphWithCycles.AddVertex(1);
            undirectedGraphWithCycles.AddVertex(2);
            undirectedGraphWithCycles.AddVertex(3);
            undirectedGraphWithCycles.AddVertex(4);
            undirectedGraphWithCycles.AddVertex(5);
            undirectedGraphWithCycles.AddVertex(6);
            undirectedGraphWithCycles.AddEdge(1, 6);
            undirectedGraphWithCycles.AddEdge(1, 2);
            undirectedGraphWithCycles.AddEdge(2, 3);
            undirectedGraphWithCycles.AddEdge(3, 4);
            undirectedGraphWithCycles.AddEdge(4, 5);
            undirectedGraphWithCycles.AddEdge(5, 2);
            undirectedGraphWithCycles.AddEdge(5, 1);
            
            var directedGraphWithCycles = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Directed);
            directedGraphWithCycles.AddVertex(1);
            directedGraphWithCycles.AddVertex(2);
            directedGraphWithCycles.AddVertex(3);
            directedGraphWithCycles.AddVertex(4);
            directedGraphWithCycles.AddVertex(5);
            directedGraphWithCycles.AddVertex(6);
            directedGraphWithCycles.AddEdge(1, 6);
            directedGraphWithCycles.AddEdge(1, 2);
            directedGraphWithCycles.AddEdge(2, 3);
            directedGraphWithCycles.AddEdge(3, 4);
            directedGraphWithCycles.AddEdge(4, 5);
            directedGraphWithCycles.AddEdge(5, 2);
            directedGraphWithCycles.AddEdge(5, 1);
            
            var undirectedGraphWithoutCycles = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Undirected);
            undirectedGraphWithoutCycles.AddVertex(1);
            undirectedGraphWithoutCycles.AddVertex(2);
            undirectedGraphWithoutCycles.AddVertex(3);
            undirectedGraphWithoutCycles.AddVertex(4);
            undirectedGraphWithoutCycles.AddVertex(5);
            undirectedGraphWithoutCycles.AddVertex(6);
            undirectedGraphWithoutCycles.AddEdge(1, 6);
            undirectedGraphWithoutCycles.AddEdge(1, 2);
            undirectedGraphWithoutCycles.AddEdge(2, 3);
            undirectedGraphWithoutCycles.AddEdge(3, 4);
            undirectedGraphWithoutCycles.AddEdge(4, 5);
            
            
            Assert.Equal(new []
            {
                "tree edge: 1-6",
                "tree edge: 1-2", 
                "tree edge: 2-3", 
                "tree edge: 3-4", 
                "tree edge: 4-5", 
                "back edge: 5-2", 
                "back edge: 5-1"
            }, DFS.DFSGraphEdgesRecursive(undirectedGraphWithCycles, 1));
            
            Assert.True(DFS.DFSGraphHasCycles(undirectedGraphWithCycles));
            
            Assert.Equal(new []
            {
                "tree edge: 1-6",
                "tree edge: 1-2", 
                "tree edge: 2-3", 
                "tree edge: 3-4", 
                "tree edge: 4-5", 
                "back edge: 5-2", 
                "back edge: 5-1"
            }, DFS.DFSGraphEdgesRecursive(directedGraphWithCycles, 1));
            
            Assert.True(DFS.DFSGraphHasCycles(directedGraphWithCycles));
            
            Assert.Equal(new []
            {
                "tree edge: 1-6",
                "tree edge: 1-2", 
                "tree edge: 2-3", 
                "tree edge: 3-4", 
                "tree edge: 4-5"
                
            }, DFS.DFSGraphEdgesRecursive(undirectedGraphWithoutCycles, 1));
            
            Assert.False(DFS.DFSGraphHasCycles(undirectedGraphWithoutCycles));
        }

        [Fact]
        public void TopologicalSortingTest()
        {
            var directedGraphWithCycles = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Directed);
            directedGraphWithCycles.AddVertex(1); // G
            directedGraphWithCycles.AddVertex(2); // A
            directedGraphWithCycles.AddVertex(3); // B
            directedGraphWithCycles.AddVertex(4); // C
            directedGraphWithCycles.AddVertex(5); // F
            directedGraphWithCycles.AddVertex(6); // E
            directedGraphWithCycles.AddVertex(7); // D
            directedGraphWithCycles.AddEdge(1, 2);
            directedGraphWithCycles.AddEdge(1, 5);
            directedGraphWithCycles.AddEdge(2, 3);
            directedGraphWithCycles.AddEdge(2, 4);
            directedGraphWithCycles.AddEdge(3, 4);
            directedGraphWithCycles.AddEdge(3, 7);
            directedGraphWithCycles.AddEdge(4, 5);
            directedGraphWithCycles.AddEdge(4, 6);
            directedGraphWithCycles.AddEdge(5, 6);
            directedGraphWithCycles.AddEdge(6, 7);
            
            Assert.Equal(new[]{1, 2, 3, 4, 5, 6, 7}, DFS.TopologicalSorting(directedGraphWithCycles));
        }
    }
}