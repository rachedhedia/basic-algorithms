using System.Collections.Generic;
using System.Linq;
using implementations;
using Xunit;

namespace tests
{
    public class BFSTest
    {
        [Fact]
        public void TraverseBinarySearchTreeIterativeTest()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");
            
            Assert.Equal(new []{"4", "2", "6", "1", "3", "5", "7"}, BFS.TraverseBinarySearchTreeIterative(binarySearchTree.Root));
        }
        
        [Fact]
        public void TraverseBinarySearchTreeRecursiveTest()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");
            
            Assert.Equal(new []{"4", "2", "6", "1", "3", "5", "7"}, BFS.TraverseBinarySearchTreeRecursive(binarySearchTree.Root));
        }

        [Fact]
        public void TraverseBinarySearchTreeByLevelIterative()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");

            Assert.Equal(new[] {"4", "26", "1357"},
                BFS.TraverseBinarySearchTreeByLevelIterative(binarySearchTree.Root).Select(
                    x => x.Aggregate((total, y) => total + y))
                );
        }
        
        [Fact]
        public void TraverseBinarySearchTreeByLevelRecursive()
        {
            var binarySearchTree = new BinarySearchTreeKey();
            binarySearchTree.Add("4");
            binarySearchTree.Add("2");
            binarySearchTree.Add("6");
            binarySearchTree.Add("1");
            binarySearchTree.Add("3");
            binarySearchTree.Add("5");
            binarySearchTree.Add("7");

            Assert.Equal(new[] {"4", "26", "1357"},
                BFS.TraverseBinarySearchTreeByLevelRecursive(binarySearchTree.Root).Select(
                    x => x.Aggregate((total, y) => total + y))
            );
        }
        
        

        [Fact]
        public void TraverseGraphIterativeTest()
        {
            var directedGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Directed);
            directedGraph.AddVertex(1);
            directedGraph.AddVertex(2);
            directedGraph.AddVertex(3);
            directedGraph.AddVertex(4);
            directedGraph.AddEdge(1, 2);
            directedGraph.AddEdge(2, 3);
            directedGraph.AddEdge(3, 4);
            directedGraph.AddEdge(4, 1);
            
            var undirectedGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Undirected);
            undirectedGraph.AddVertex(1);
            undirectedGraph.AddVertex(2);
            undirectedGraph.AddVertex(3);
            undirectedGraph.AddVertex(4);
            undirectedGraph.AddEdge(1, 2);
            undirectedGraph.AddEdge(2, 3);
            undirectedGraph.AddEdge(3, 4);
            undirectedGraph.AddEdge(4, 1);
            
            Assert.Equal(new []{1, 2, 3, 4}, BFS.TraverseGraphIterative(directedGraph));
            Assert.Equal(new []{1, 2, 4, 3}, BFS.TraverseGraphIterative(undirectedGraph));
        }
        
        [Fact]
        public void TraverseGraphRecursiveTest()
        {
            var directedGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Directed);
            directedGraph.AddVertex(1);
            directedGraph.AddVertex(2);
            directedGraph.AddVertex(3);
            directedGraph.AddVertex(4);
            directedGraph.AddEdge(1, 2);
            directedGraph.AddEdge(2, 3);
            directedGraph.AddEdge(3, 4);
            directedGraph.AddEdge(4, 1);
            
            var undirectedGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Undirected);
            undirectedGraph.AddVertex(1);
            undirectedGraph.AddVertex(2);
            undirectedGraph.AddVertex(3);
            undirectedGraph.AddVertex(4);
            undirectedGraph.AddEdge(1, 2);
            undirectedGraph.AddEdge(2, 3);
            undirectedGraph.AddEdge(3, 4);
            undirectedGraph.AddEdge(4, 1);
            
            Assert.Equal(new []{1, 2, 3, 4}, BFS.TraverseGraphRecursive(directedGraph));
            Assert.Equal(new []{1, 2, 4, 3}, BFS.TraverseGraphRecursive(undirectedGraph));
        }

        [Fact]
        public void TraverseGraphWithEdgesIterativeTest()
        {
            var directedGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Directed);
            directedGraph.AddVertex(1);
            directedGraph.AddVertex(2);
            directedGraph.AddVertex(3);
            directedGraph.AddVertex(4);
            directedGraph.AddEdge(1, 2);
            directedGraph.AddEdge(2, 3);
            directedGraph.AddEdge(3, 4);
            directedGraph.AddEdge(4, 1);
            
            var undirectedGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Undirected);
            undirectedGraph.AddVertex(1);
            undirectedGraph.AddVertex(2);
            undirectedGraph.AddVertex(3);
            undirectedGraph.AddVertex(4);
            undirectedGraph.AddEdge(1, 2);
            undirectedGraph.AddEdge(2, 3);
            undirectedGraph.AddEdge(3, 4);
            undirectedGraph.AddEdge(4, 1);
            
            Assert.Equal(new []{1, 2, 3, 4}, BFS.TraverseGraphWithEdgesIterative(directedGraph).Item1);
            Assert.Equal(new []{"1-2", "2-3", "3-4", "4-1"}, BFS.TraverseGraphWithEdgesIterative(directedGraph).Item2);
            Assert.Equal(new []{1, 2, 4, 3}, BFS.TraverseGraphWithEdgesIterative(undirectedGraph).Item1);
            Assert.Equal(new []{"1-2", "1-4", "2-3", "4-3"}, BFS.TraverseGraphWithEdgesIterative(undirectedGraph).Item2);
        }

        [Fact]
        public void GetConnectedComponentsCountTest()
        {
            var singleComponentGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Undirected);
            singleComponentGraph.AddVertex(1);
            singleComponentGraph.AddVertex(2);
            singleComponentGraph.AddVertex(3);
            singleComponentGraph.AddVertex(4);
            singleComponentGraph.AddEdge(1, 2);
            singleComponentGraph.AddEdge(2, 3);
            singleComponentGraph.AddEdge(3, 4);
            singleComponentGraph.AddEdge(4, 1);
            
            var twoComponentsGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Undirected);
            twoComponentsGraph.AddVertex(1);
            twoComponentsGraph.AddVertex(2);
            twoComponentsGraph.AddVertex(3);
            twoComponentsGraph.AddVertex(4);
            twoComponentsGraph.AddEdge(1, 2);
            twoComponentsGraph.AddEdge(2, 3);
            
            Assert.Equal(2, BFS.GetConnectedComponentsCount(twoComponentsGraph));
        }
    }
}