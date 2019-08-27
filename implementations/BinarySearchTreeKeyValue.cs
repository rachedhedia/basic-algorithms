using System;
using System.Collections.Generic;
using System.Linq;

namespace implementations
{
    public class BinarySearchTreeKeyValue<TValueType> where TValueType : struct
    {
        private class Node
        {
            public Node(string key, TValueType value, Node parent)
            {
                Key = key;
                Value = value;
                Parent = parent;
                Left = null;
                Right = null;
            }
            
            public string Key { get;}
            public TValueType Value { get; }
            public Node Parent { get; set; }
            public Node Left { get; set;  }
            public Node Right { get; set; }
        }

        private Node _root = null;
        
        public void Add(string key, TValueType value)
        {
            if (Contains(key))
                return;
            
            if (_root == null)
            {
                _root = new Node(key, value, null);
            }
            else
            {
                var currentNode = _root;
                while (currentNode != null)
                {
                    var stringComparison = String.CompareOrdinal(key, currentNode.Key);
                    
                    if (stringComparison < 0)
                    {
                        if(currentNode.Left != null)
                            currentNode = currentNode.Left;
                        else
                        {
                            currentNode.Left = new Node(key, value, currentNode);
                            return;
                        }
                    }
                    else if (stringComparison > 0)
                    {
                        if (currentNode.Right != null)
                            currentNode = currentNode.Right;
                        else
                        {
                            currentNode.Right = new Node(key, value, currentNode);
                            return;
                        }
                    }
                }
            }
        }

        public void Remove(string key)
        {
            var toBeRemovedNode = SearchNode(key);
            
            if (toBeRemovedNode == null) return;

            if (toBeRemovedNode.Left == null && toBeRemovedNode.Right == null)
            {
                if (toBeRemovedNode == _root)
                    _root = null;
                else
                {
                    if (toBeRemovedNode == toBeRemovedNode.Parent.Left)
                        toBeRemovedNode.Parent.Left = null;
                    else
                    {
                        toBeRemovedNode.Parent.Right = null;
                    }
                }
            }
            else if(toBeRemovedNode.Left != null && toBeRemovedNode.Right == null)
            {
                if (toBeRemovedNode == _root)
                {
                    _root = toBeRemovedNode.Left;
                    toBeRemovedNode.Left.Parent = null;
                }
                    
                else
                {
                    if (toBeRemovedNode == toBeRemovedNode.Parent.Left)
                    {
                        toBeRemovedNode.Parent.Left = toBeRemovedNode.Left;
                    }
                    else
                    {
                        toBeRemovedNode.Parent.Right = toBeRemovedNode.Left;
                    }
                    toBeRemovedNode.Left.Parent = toBeRemovedNode.Parent;
                }
            }
            else if(toBeRemovedNode.Left == null && toBeRemovedNode.Right != null)
            {
                if (toBeRemovedNode == _root)
                {
                    _root = toBeRemovedNode.Right;
                    toBeRemovedNode.Right.Parent = null;
                }
                    
                else
                {
                    if (toBeRemovedNode == toBeRemovedNode.Parent.Left)
                    {
                        toBeRemovedNode.Parent.Left = toBeRemovedNode.Right;
                    }
                        
                    else
                    {
                        toBeRemovedNode.Parent.Right = toBeRemovedNode.Right;
                    }
                    toBeRemovedNode.Right.Parent = toBeRemovedNode.Parent;
                }
            }
            else
            {
                
                    var rightMinNode = GetMinNode(toBeRemovedNode.Right);
                    if (rightMinNode.Parent.Left == rightMinNode)
                        rightMinNode.Parent.Left = null;
                    else
                    {
                        rightMinNode.Parent.Right = null;
                    }
                
                rightMinNode.Left = toBeRemovedNode.Left;
                    
                if(rightMinNode.Left != null)
                    rightMinNode.Left.Parent = rightMinNode;
                    
                rightMinNode.Right = toBeRemovedNode.Right;
                    
                if(rightMinNode.Right != null)
                    rightMinNode.Right.Parent = rightMinNode;
                
                if (toBeRemovedNode == _root)
                {
                    rightMinNode.Parent = null;
                    _root = rightMinNode;
                }
                else
                {
                    if (toBeRemovedNode.Parent.Left == toBeRemovedNode)
                        toBeRemovedNode.Parent.Left = rightMinNode;
                    else
                    {
                        toBeRemovedNode.Parent.Right = rightMinNode;
                    }
                }
            }
        }

        private Node SearchNode(string key)
        {
            if (_root == null)
                return null;
            
            var currentNode = _root;
            while (currentNode != null)
            {
                if (currentNode.Key == key)
                    return currentNode;
                    
                var stringComparison = String.CompareOrdinal(key, currentNode.Key);
                currentNode = stringComparison < 0 ? currentNode.Left : currentNode.Right;
            }

            return null;
        }

        public TValueType? GetValue(string key)
        {
            return SearchNode(key)?.Value;
        }

        public bool Contains(string key)
        {
            return SearchNode(key) != null;
        }

        public Tuple<string, TValueType> GetMin()
        {
            var currentNode = GetMinNode(_root);
            return currentNode == null ? null : new Tuple<string, TValueType>(currentNode.Key, currentNode.Value);
        }

        private Node GetMinNode(Node root)
        {
            if (root == null)
                return null;

            var currentNode = root;
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode;
        }

        public Tuple<string, TValueType> GetMax()
        {
            if (_root == null)
                return null;

            var currentNode = _root;
            while (currentNode.Right != null)
            {
                currentNode = currentNode.Right;
            }

            return new Tuple<string, TValueType>(currentNode.Key, currentNode.Value);
        }

        public IEnumerable<Tuple<string, TValueType>> Traverse()
        {
            if (_root == null)
                yield break;
            var nodes = new Queue<Node>();
            nodes.Enqueue(_root);
            while (!nodes.Empty())
            {
                var currentNode = nodes.Dequeue();
                
                if (currentNode == null)
                    continue;
                
                yield return new Tuple<string, TValueType>(currentNode.Key, currentNode.Value);
                
                nodes.Enqueue(currentNode.Left);
                nodes.Enqueue(currentNode.Right);
            }
        }
    }
}