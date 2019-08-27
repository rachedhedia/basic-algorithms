using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace implementations
{
    public class BFS
    {
        public static IEnumerable<string> TraverseBinarySearchTreeIterative(BinarySearchTreeKey.Node node)
        {
            var traversedNodes = new List<string>();
            var toBeTraversedNodes = new Queue<BinarySearchTreeKey.Node>();
            toBeTraversedNodes.Enqueue(node);

            while (!toBeTraversedNodes.Empty())
            {
                var currentNode = toBeTraversedNodes.Dequeue();
                if (currentNode == null) continue;
                traversedNodes.Add(currentNode.Key);
                toBeTraversedNodes.Enqueue(currentNode.Left);
                toBeTraversedNodes.Enqueue(currentNode.Right);
            }

            return traversedNodes;
        }

        public static IEnumerable<IEnumerable<string>> TraverseBinarySearchTreeByLevelIterative(BinarySearchTreeKey.Node node)
        {
            var traversedNodesByLevel = new List<List<string>>();
            var toBeTraversedNodes = new Queue<BinarySearchTreeKey.Node>();
            
            toBeTraversedNodes.Enqueue(node);
            
            var currentLevelNodes = new Queue<BinarySearchTreeKey.Node>();

            while (!toBeTraversedNodes.Empty())
            {
                while(!toBeTraversedNodes.Empty())
                    currentLevelNodes.Enqueue(toBeTraversedNodes.Dequeue());
                
                traversedNodesByLevel.Add(new List<string>());
                
                while (!currentLevelNodes.Empty())
                {
                    var currentNode = currentLevelNodes.Dequeue();
                    if (currentNode == null) continue;
                    traversedNodesByLevel.Last().Add(currentNode.Key);
                    if(currentNode.Left != null)
                        toBeTraversedNodes.Enqueue(currentNode.Left);
                    if(currentNode.Right != null)
                        toBeTraversedNodes.Enqueue(currentNode.Right);
                }
            }

            return traversedNodesByLevel;
        }
        
        public static IEnumerable<IEnumerable<string>> TraverseBinarySearchTreeByLevelRecursive(
            BinarySearchTreeKey.Node node)
        {
            var toBeTraversedNodes = new Queue<BinarySearchTreeKey.Node>();
            toBeTraversedNodes.Enqueue(node);
            return TraverseBinarySearchTreeByLevelRecursive(toBeTraversedNodes);
        }

        private static IEnumerable<List<string>> TraverseBinarySearchTreeByLevelRecursive(Queue<BinarySearchTreeKey.Node> toBeTraversedNodes)
        {
            if (toBeTraversedNodes.Empty())
                return new List<List<string>>();;
            
            var levelTraversedNodes = new List<string>();
            
            var newToBeTraversedNodes = new Queue<BinarySearchTreeKey.Node>();
            
            while (!toBeTraversedNodes.Empty())
            {
                var currentNode = toBeTraversedNodes.Dequeue();
                if (currentNode == null) continue;
                levelTraversedNodes.Add(currentNode.Key);
                if (currentNode.Left != null)
                    newToBeTraversedNodes.Enqueue(currentNode.Left);
                if (currentNode.Right != null)
                    newToBeTraversedNodes.Enqueue(currentNode.Right);
            }

            var byLevelTraversedNodes = new List<List<string>> {levelTraversedNodes};
            byLevelTraversedNodes.AddRange(TraverseBinarySearchTreeByLevelRecursive(newToBeTraversedNodes));
            return byLevelTraversedNodes;
        }


        public static IEnumerable<string> TraverseBinarySearchTreeRecursive(BinarySearchTreeKey.Node node)
        {
            var toBeTraversedNodes = new Queue<BinarySearchTreeKey.Node>();
            toBeTraversedNodes.Enqueue(node);

            return TraverseBinarySearchTreeRecursive(toBeTraversedNodes);
        }
        
        private static IEnumerable<string> TraverseBinarySearchTreeRecursive(
            Queue<BinarySearchTreeKey.Node> toBeTraversedNodes)
        {
            if (toBeTraversedNodes.Empty()) 
                return Enumerable.Empty<string>();
            
            var newToBeTraversedNodes = new Queue<BinarySearchTreeKey.Node>();
            var traversedNodes = new List<string>();

            while (!toBeTraversedNodes.Empty())
            {
                var currentNode = toBeTraversedNodes.Dequeue();
                if (currentNode == null) continue;
                
                traversedNodes.Add(currentNode.Key);
                newToBeTraversedNodes.Enqueue(currentNode.Left);
                newToBeTraversedNodes.Enqueue(currentNode.Right);
            }

            return traversedNodes.Concat(TraverseBinarySearchTreeRecursive(newToBeTraversedNodes));
        }

        public static IEnumerable<int> TraverseGraphIterative(GraphAdjacentLists<int> graph, int? vertex = null)
        {
            if (!graph.FirstVertex.HasValue)
                return Enumerable.Empty<int>();

            if (!vertex.HasValue)
                vertex = graph.FirstVertex;
            
            var returnValue = new List<int>();
            var traversedNodes = new HashSet<int>();
            var toBeTraversedNodes = new Queue<int>();
            toBeTraversedNodes.Enqueue(vertex.Value);

            while (!toBeTraversedNodes.Empty())
            {
                var currentNode = toBeTraversedNodes.Dequeue();
                if (traversedNodes.Contains(currentNode)) continue;
                traversedNodes.Add(currentNode);
                
                returnValue.Add(currentNode);

                foreach (var node in graph.GetAdjacentVertices(currentNode))
                    toBeTraversedNodes.Enqueue(node);
            }

            return returnValue;
        }

        public static IEnumerable<int> TraverseGraphRecursive(GraphAdjacentLists<int> graph)
        {
            if (!graph.FirstVertex.HasValue)
                return Enumerable.Empty<int>();
            
            var toBeTraversedNodes = new Queue<int>();
            toBeTraversedNodes.Enqueue(graph.FirstVertex.Value);


            return TraverseGraphRecursive(graph, toBeTraversedNodes, new HashSet<int>());
        }
        
        private static IEnumerable<int> TraverseGraphRecursive(GraphAdjacentLists<int> graph, 
            Queue<int> toBeTraversedNodes, HashSet<int> traversedNodes)
        {
            if (toBeTraversedNodes.Empty())
                return Enumerable.Empty<int>();

            var returnValue = new List<int>();
            var newToBeTraversedNodes = new Queue<int>();

            while (!toBeTraversedNodes.Empty())
            {
                var currentNode = toBeTraversedNodes.Dequeue();
                if (traversedNodes.Contains(currentNode)) continue;

                traversedNodes.Add(currentNode);
                returnValue.Add(currentNode);
                
                foreach (var node in graph.GetAdjacentVertices(currentNode))
                    newToBeTraversedNodes.Enqueue(node);
            }

            return returnValue.Concat(TraverseGraphRecursive(graph, newToBeTraversedNodes, traversedNodes));
        }

        public static (IEnumerable<int>, IEnumerable<string>) TraverseGraphWithEdgesIterative(GraphAdjacentLists<int> graph)
        {
            if (!graph.FirstVertex.HasValue)
                return (Enumerable.Empty<int>(), Enumerable.Empty<string>());
            
            var processedNodes = new HashSet<int>();
            var traversedEdges = new HashSet<Tuple<int, int>>();
            var toBeTraversedNodes = new Queue<int>();
            toBeTraversedNodes.Enqueue(graph.FirstVertex.Value);

            while (!toBeTraversedNodes.Empty())
            {
                var currentNode = toBeTraversedNodes.Dequeue();
                processedNodes.Add(currentNode);

                foreach (var node in graph.GetAdjacentVertices(currentNode))
                {
                    if (graph.DirectedGraph == GraphAdjacentLists<int>.DirectedGraphEnum.Directed || 
                        !processedNodes.Contains(node))
                    {
                        traversedEdges.Add(new Tuple<int, int>(currentNode, node));
                    }

                    if (!processedNodes.Contains(node))
                    {
                        toBeTraversedNodes.Enqueue(node);   
                    }
                    
                }
            }

            return (processedNodes, traversedEdges.Select(x => x.Item1 + "-" + x.Item2));
        }

        public static int GetConnectedComponentsCount(GraphAdjacentLists<int> graph)
        {
            var componentId = 0;
            var vertexToComponentTable = new Dictionary<int, int>();

            foreach (var vertex in graph.Vertices)
            {
                if (vertexToComponentTable.ContainsKey(vertex)) continue;
                ++componentId;
                var traversedNodes = TraverseGraphIterative(graph, vertex);
                foreach (var traversedNode in traversedNodes)
                {
                    if(!vertexToComponentTable.ContainsKey(traversedNode))
                        vertexToComponentTable[traversedNode] = componentId;
                }
            }

            return componentId;
        }

        public struct GraphComponent<TValueType> where TValueType : struct
        {
            public enum TypeEnum
            {
                Node,
                Edge
            }
            
            public TypeEnum Type { get; set; }
            public TValueType? ParentNode { get; set; }
            public TValueType? NodeValue;
            public bool? NodeIsProcessed;
            public TValueType? EdgeStart;
            public TValueType? EdgeEnd;
        }

        public static IEnumerable<GraphComponent<int>> BFSGraphIterative(GraphAdjacentLists<int> graph, int startNode)
        {
            var discoveredNodesQueue = new Queue<Tuple<int?, int>>();
            var discoveredNodes = new HashSet<int>();
            var processedNodesQueue = new Queue<int>();
            var processedNodes = new HashSet<int>();
            
            discoveredNodesQueue.Enqueue(new Tuple<int?, int>(null, startNode));
            discoveredNodes.Add(startNode);

            while (discoveredNodesQueue.Empty())
            {
                var currentNodeInfo = discoveredNodesQueue.Dequeue();
                var currentNodeParent = currentNodeInfo.Item1;
                var currentNode = currentNodeInfo.Item2;
                
                yield return new GraphComponent<int>
                {
                    Type = GraphComponent<int>.TypeEnum.Node,
                    ParentNode = currentNodeParent,
                    NodeValue = currentNode,
                    NodeIsProcessed = false
                };
                
                foreach (var node in graph.GetAdjacentVertices(currentNode))
                {
                    if (!processedNodes.Contains(node) ||
                        graph.DirectedGraph == GraphAdjacentLists<int>.DirectedGraphEnum.Directed)
                    {
                        yield return new GraphComponent<int>
                        {
                            Type = GraphComponent<int>.TypeEnum.Edge,
                            EdgeStart = currentNode,
                            EdgeEnd = node
                        };
                    }
                    
                    if (!discoveredNodes.Contains(node))
                    {
                        discoveredNodesQueue.Enqueue(new Tuple<int?, int>(currentNode, node));
                    }
                }

                processedNodes.Add(currentNode);
                processedNodesQueue.Enqueue(currentNode);
                
                yield return new GraphComponent<int>
                {
                    Type = GraphComponent<int>.TypeEnum.Node,
                    NodeValue = currentNode,
                    NodeIsProcessed = true
                };
            }
        }

        /*public static IEnumerable<int> ShortestPath(GraphAdjacentLists<int> graph, int fromNode, int toNode)
        {
            
        }*/
    }
}

