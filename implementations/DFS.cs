using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;

namespace implementations
{
    public class DFS
    {
        public static IEnumerable<string> DFSBinarySearchTreeInOrderRecursive(BinarySearchTreeKey.Node node)
        {
            var returnValue = new List<string>();
            if (node == null)
                return Enumerable.Empty<string>();

            returnValue.AddRange(DFSBinarySearchTreeInOrderRecursive(node.Left));
            returnValue.Add(node.Key);
            returnValue.AddRange(DFSBinarySearchTreeInOrderRecursive(node.Right));

            return returnValue;
        }

        public static IEnumerable<string> DFSBinarySearchTreeInOrderIterative(BinarySearchTreeKey.Node node)
        {
            var visitedNodes = new List<string>();
            var toBeVisitedNodes = new Stack<BinarySearchTreeKey.Node>();
            var currentNode = node;

            while (currentNode != null || toBeVisitedNodes.Any())
            {
                if (currentNode != null)
                {
                    toBeVisitedNodes.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = toBeVisitedNodes.Pop();
                    visitedNodes.Add(currentNode.Key);
                    currentNode = currentNode.Right;
                }
            }

            return visitedNodes;
        }
        
        public static IEnumerable<string> DFSBinarySearchTreePreOrderRecursive(BinarySearchTreeKey.Node node)
        {
            var returnValue = new List<string>();
            if (node == null)
                return Enumerable.Empty<string>();

            returnValue.Add(node.Key);
            returnValue.AddRange(DFSBinarySearchTreePreOrderRecursive(node.Left));
            returnValue.AddRange(DFSBinarySearchTreePreOrderRecursive(node.Right));

            return returnValue;
        }

        public static IEnumerable<string> DFSBinarySearchTreePreOrderIterative(BinarySearchTreeKey.Node node)
        {
            var visitedNodes = new List<string>();
            var toBeVisitedNodes = new Stack<BinarySearchTreeKey.Node>();
            var currentNode = node;

            while (currentNode != null || toBeVisitedNodes.Any())
            {
                if (currentNode != null)
                {
                    visitedNodes.Add(currentNode.Key);
                    toBeVisitedNodes.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = toBeVisitedNodes.Pop();
                    currentNode = currentNode.Right;
                }
            }

            return visitedNodes;
        }
        
        public static IEnumerable<string> DFSBinarySearchTreePostOrderRecursive(BinarySearchTreeKey.Node node)
        {
            var returnValue = new List<string>();
            if (node == null)
                return Enumerable.Empty<string>();

            returnValue.AddRange(DFSBinarySearchTreePostOrderRecursive(node.Left));
            returnValue.AddRange(DFSBinarySearchTreePostOrderRecursive(node.Right));
            returnValue.Add(node.Key);

            return returnValue;
        }
        
        public static IEnumerable<string> DFSBinarySearchTreePostOrderIterative(BinarySearchTreeKey.Node node)
        {
            var visitedNodes = new List<string>();
            var toBeVisitedNodes = new Stack<BinarySearchTreeKey.Node>();
            var currentNode = node;
            BinarySearchTreeKey.Node prevNode = null;

            while (currentNode != null || toBeVisitedNodes.Any())
            {
                if (currentNode != null)
                {
                    toBeVisitedNodes.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    var stackTopNode = toBeVisitedNodes.Pop();
                    if (stackTopNode.Right != null && stackTopNode.Right != prevNode)
                    {
                        currentNode = stackTopNode.Right;
                        toBeVisitedNodes.Push(stackTopNode);
                    }
                    else
                    {
                        currentNode = stackTopNode;
                        visitedNodes.Add(currentNode.Key);
                        prevNode = currentNode;
                        currentNode = null;
                    }
                }
            }

            return visitedNodes;
        }

        public static IEnumerable<Tuple<int, int, int>> DFSGraphNodesRecursive(GraphAdjacentLists<int> graph, int startNode, 
            HashSet<int> discoveredNodes = null, HashSet<int> processedNodes = null, int? timer = null)
        {
            if (!graph.HasVertex(startNode))
                yield break;

            var currentNode = startNode;
            
            if (discoveredNodes == null)
                discoveredNodes = new HashSet<int>();
            
            if (processedNodes == null)
                processedNodes = new HashSet<int>();

            if (!timer.HasValue)
                timer = 0;

            discoveredNodes.Add(currentNode);
            
            var entryTime = timer.Value;
            ++timer;

            foreach (var node in graph.GetAdjacentVertices(currentNode))
            {
                if (discoveredNodes.Contains(node)) continue;
                
                foreach (var subNode in DFSGraphNodesRecursive(graph, node, discoveredNodes, processedNodes, timer))
                    yield return subNode;
            }

            processedNodes.Add(currentNode);
            ++timer;
            var exitTime = timer.Value;
            
            yield return new Tuple<int, int, int>(startNode, entryTime, exitTime);
        }
        
        public static IEnumerable<string> DFSGraphEdgesRecursive(GraphAdjacentLists<int> graph, int startNode, 
            HashSet<int> discoveredNodes = null, HashSet<int> processedNodes = null, 
            Dictionary<int, int> parentNodes = null, int parentNode = -1)
        {
            if (!graph.HasVertex(startNode))
                yield break;

            var currentNode = startNode;
            
            if (discoveredNodes == null)
                discoveredNodes = new HashSet<int>();

            if (processedNodes == null)
                processedNodes = new HashSet<int>();
            
            if (parentNodes == null)
                parentNodes = new Dictionary<int, int>();

            parentNodes[currentNode] = parentNode;

            discoveredNodes.Add(currentNode);
            
            foreach (var node in graph.GetAdjacentVertices(currentNode))
            {
                if (processedNodes.Contains(node))
                {
                    if (graph.DirectedGraph == GraphAdjacentLists<int>.DirectedGraphEnum.Directed)
                    {
                        yield return "back edge: " + currentNode + "-" + node;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (discoveredNodes.Contains(node))
                {
                    if (parentNode == node)
                        continue;
                    else
                        yield return "back edge: " + currentNode + "-" + node;
                }
                else if (!discoveredNodes.Contains(node))
                {
                    parentNodes[node] = currentNode;
                    yield return "tree edge: " + currentNode + "-" + node;
                    foreach (var subEdge in DFSGraphEdgesRecursive(graph, node, discoveredNodes, processedNodes, parentNodes, currentNode))
                        yield return subEdge;
                }
            }

            processedNodes.Add(currentNode);
        }
        
        public static bool DFSGraphHasCycles(GraphAdjacentLists<int> graph)
        {
            return DFSGraphEdgesRecursive(graph, graph.Vertices.First()).Any(edge => edge.Contains("back"));
        }

        public static IEnumerable<int> TopologicalSorting(GraphAdjacentLists<int> graph)
        {
            if (graph.DirectedGraph == GraphAdjacentLists<int>.DirectedGraphEnum.Undirected)
                return Enumerable.Empty<int>();

            var traversedNodesStack = new Stack<int>();
            var traversedNodes = new List<int>();

            foreach (var node in graph.Vertices)
            {
                traversedNodesStack.Clear();
                
                foreach (var traversedNode in DFSGraphNodesRecursive(graph, node))
                    traversedNodesStack.Push(traversedNode.Item1);

                if (traversedNodesStack.Count() == graph.Vertices.Count())
                    break;
            }
            
            foreach(var traversedNode in traversedNodesStack)
                traversedNodes.Add(traversedNode);

            return traversedNodes;
        }
    }
}
