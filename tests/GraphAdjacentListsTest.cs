using implementations;
using Xunit;

namespace tests
{
    public class GraphAdjacentListsTest
    {
        [Fact]
        public void Test()
        {
            var emptyGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Directed);
            var nonEmptyGraph = new GraphAdjacentLists<int>(GraphAdjacentLists<int>.DirectedGraphEnum.Directed);
            nonEmptyGraph.AddVertex(1);
            nonEmptyGraph.AddVertex(2);
            nonEmptyGraph.AddVertex(3);
            nonEmptyGraph.AddVertex(4);
            nonEmptyGraph.AddEdge(1,2);
            nonEmptyGraph.AddEdge(2,3);
            nonEmptyGraph.AddEdge(3,4);
            nonEmptyGraph.AddEdge(4,2);
            
            
            Assert.Equal(0, emptyGraph.NumberOfVertices);
            Assert.Equal(0, emptyGraph.NumberOfEdges);
            Assert.Equal(4, nonEmptyGraph.NumberOfVertices);
            Assert.Equal(4, nonEmptyGraph.NumberOfEdges);
            Assert.Equal(true, nonEmptyGraph.HasEdge(1, 2));
            Assert.Equal(false, nonEmptyGraph.HasEdge(2, 1));
            Assert.Equal(false, nonEmptyGraph.HasEdge(4, 1));
        }
    }
}