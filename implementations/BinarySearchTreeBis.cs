using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Transactions;

namespace implementations
{
    public class BinarySearchTreeBis
    {
        class Node
        {
            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }

            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; }
        }

        private Node _root = null;

        private static void Add(Node rootNode, int value)
        {
            if (value == rootNode.Value)
            {
                return;
            }

            if (value < rootNode.Value)
            {
                if(rootNode.Left != null)
                    Add(rootNode.Left, value);
                else
                    rootNode.Left = new Node(value);
            }
            else if (value > rootNode.Value)
            {
                if(rootNode.Right != null)
                    Add(rootNode.Right, value);
                else
                    rootNode.Right = new Node(value);
            }
        }
        
        public void Add(int value)
        {
            if (_root == null)
            {
                _root = new Node(value);
                return;
            }
            
            Add(_root, value);
        }

        public void Remove(int value)
        {
            
        }

        public int GetMin()
        {
            return TraverseDfsInOrderIterative().First();
        }

        public int GetMax()
        {
            return TraverseDfsReverseOrderIterative().First();
        }

        public string GetStringRepresentation()
        {
            var levelStringRepresentation = "";
            
            foreach (var level in TraverseByLevel())
            {
                levelStringRepresentation = level.Aggregate("", (result, next) => result + " " + next);
            }

            return levelStringRepresentation;
        }

        public IEnumerable<int> TraverseBfs()
        {
            var nodesQueue = new System.Collections.Generic.Queue<Node>();
            nodesQueue.Enqueue(_root);

            while (nodesQueue.Count > 0)
            {
                var node = nodesQueue.Dequeue();
                if (node.Left != null)
                    nodesQueue.Enqueue(node.Left);
                if (node.Right != null)
                    nodesQueue.Enqueue(node.Right);
                yield return node.Value;
            }
        }
        
        // DFS Iterative

        public IEnumerable<int> TraverseDfsInOrderIterative()
        {
            var nodeStack = new Stack<Node>();
            var node = _root;
            
            while (nodeStack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    nodeStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = nodeStack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
        
        public IEnumerable<int> TraverseDfsPreOrderIterative()
        {
            var nodeStack = new Stack<Node>();
            var node = _root;
            
            while (nodeStack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    yield return node.Value;
                    nodeStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = nodeStack.Pop();
                    node = node.Right;
                }
            }
        }

        public IEnumerable<int> TraverseDfsPostOrderIterative()
        {
            var nodeStack = new Stack<Node>();
            var node = _root;
            
            while (nodeStack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    nodeStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    var tempNode = nodeStack.Peek().Right;
                    if (tempNode != null)
                        node = tempNode;
                    else
                    {
                        tempNode = nodeStack.Pop();
                        yield return tempNode.Value;

                        while (nodeStack.Count > 0 && nodeStack.Peek().Right.Value == tempNode.Value)
                        {
                            tempNode = nodeStack.Pop();
                            yield return tempNode.Value;
                        }

                    }
                }
            }
        }

        public IEnumerable<int> TraverseDfsReverseOrderIterative()
        {
            var nodeStack = new Stack<Node>();
            var node = _root;
            
            while (nodeStack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    nodeStack.Push(node);
                    node = node.Right;
                }
                else
                {
                    node = nodeStack.Pop();
                    yield return node.Value;
                    node = node.Left;
                }
            }
        }
        
        // DFS recursive

        private IEnumerable<int> _TraverseDfsInOrderRecursive(Node root)
        {
            if (root == null) yield break;
            
            if (root.Left != null)
                foreach(var node in _TraverseDfsInOrderRecursive(root.Left)) 
                    yield return node;
            yield return root.Value;
            if(root.Right != null)
                foreach (var node in _TraverseDfsInOrderRecursive(root.Right))
                    yield return node;
        }
        
        public IEnumerable<int> TraverseDfsInOrderRecursive()
        {
            return _TraverseDfsInOrderRecursive(_root);
        }
        
        private IEnumerable<int> _TraverseDfsPreOrderRecursive(Node root)
        {
            if (root == null) yield break;

            yield return root.Value;
            if (root.Left != null)
                foreach(var node in _TraverseDfsPreOrderRecursive(root.Left)) 
                    yield return node;
            if(root.Right != null)
                foreach (var node in _TraverseDfsPreOrderRecursive(root.Right))
                    yield return node;
        }
        
        public IEnumerable<int> TraverseDfsPreOrderRecursive()
        {
            return _TraverseDfsPreOrderRecursive(_root);
        }

        private IEnumerable<int> _TraverseDfsPostOrderRecursive(Node root)
        {
            if (root == null) yield break;

            if (root.Left != null)
                foreach(var node in _TraverseDfsPostOrderRecursive(root.Left)) 
                    yield return node;
            if(root.Right != null)
                foreach (var node in _TraverseDfsPostOrderRecursive(root.Right))
                    yield return node;
            yield return root.Value;
        }
        
        public IEnumerable<int> TraverseDfsPostOrderRecursive()
        {
            return _TraverseDfsPostOrderRecursive(_root);
        }

        private IEnumerable<int> _TraverseDfsReverseOrderRecursive(Node root)
        {
            if (root == null) yield break;

            if (root.Right != null)
                foreach(var node in _TraverseDfsReverseOrderRecursive(root.Right)) 
                    yield return node;
            yield return root.Value;
            if(root.Left != null)
                foreach (var node in _TraverseDfsReverseOrderRecursive(root.Left))
                    yield return node;
            
        }
        
        public IEnumerable<int> TraverseDfsReverseOrderRecursive()
        {
            return _TraverseDfsReverseOrderRecursive(_root);
        }

        public IEnumerable<IEnumerable<int>> TraverseByLevel()
        {
            var nodesQueue = new System.Collections.Generic.Queue<Node>();
            nodesQueue.Enqueue(_root);
            
            while (nodesQueue.Count > 0)
            {
                var currentLevelNodes = nodesQueue.Count;
                var currentLevel = new List<int>();
                for (var index = 0; index < currentLevelNodes; ++index)
                {
                    var node = nodesQueue.Dequeue();
                    currentLevel.Add(node.Value);
                    if(node.Left != null)
                        nodesQueue.Enqueue(node.Left);
                    if (node.Right != null)
                        nodesQueue.Enqueue(node.Right);
                }

                yield return currentLevel;
            }
        }
    }
}