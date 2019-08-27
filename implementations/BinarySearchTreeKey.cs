using System;
using System.Collections.Generic;

namespace implementations
{
    public class BinarySearchTreeKey
    {
        public class Node
        {
            public Node(string key, Node parent)
            {
                Key = key;
                Parent = parent;
                Left = null;
                Right = null;
            }
            
            public string Key { get;}
            public Node Parent { get; set; }
            public Node Left { get; set;  }
            public Node Right { get; set; }
        }

        public BinarySearchTreeKey()
        {
            Root = null;
        }
        
        public Node Root { get; set; }
        
        public void Add(string key)
        {
            if (Contains(key))
                return;
            
            if (Root == null)
            {
                Root = new Node(key, null);
            }
            else
            {
                var currentNode = Root;
                while (currentNode != null)
                {
                    var stringComparison = String.CompareOrdinal(key, currentNode.Key);
                    
                    if (stringComparison < 0)
                    {
                        if(currentNode.Left != null)
                            currentNode = currentNode.Left;
                        else
                        {
                            currentNode.Left = new Node(key, currentNode);
                            return;
                        }
                    }
                    else if (stringComparison > 0)
                    {
                        if (currentNode.Right != null)
                            currentNode = currentNode.Right;
                        else
                        {
                            currentNode.Right = new Node(key, currentNode);
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
                if (toBeRemovedNode == Root)
                    Root = null;
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
                if (toBeRemovedNode == Root)
                {
                    Root = toBeRemovedNode.Left;
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
                if (toBeRemovedNode == Root)
                {
                    Root = toBeRemovedNode.Right;
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
                
                if (toBeRemovedNode == Root)
                {
                    rightMinNode.Parent = null;
                    Root = rightMinNode;
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
            if (Root == null)
                return null;
            
            var currentNode = Root;
            while (currentNode != null)
            {
                if (currentNode.Key == key)
                    return currentNode;
                    
                var stringComparison = String.CompareOrdinal(key, currentNode.Key);
                currentNode = stringComparison < 0 ? currentNode.Left : currentNode.Right;
            }

            return null;
        }

        public bool Contains(string key)
        {
            return SearchNode(key) != null;
        }

        public string GetMin()
        {
            var currentNode = GetMinNode(Root);
            return currentNode == null ? null : currentNode.Key;
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

        public string GetMax()
        {
            if (Root == null)
                return null;

            var currentNode = Root;
            while (currentNode.Right != null)
            {
                currentNode = currentNode.Right;
            }

            return currentNode.Key;
        }

        public IEnumerable<string> Traverse()
        {
            if (Root == null)
                yield break;
            var nodes = new Queue<Node>();
            nodes.Enqueue(Root);
            while (!nodes.Empty())
            {
                var currentNode = nodes.Dequeue();
                
                if (currentNode == null)
                    continue;
                
                yield return currentNode.Key;
                
                nodes.Enqueue(currentNode.Left);
                nodes.Enqueue(currentNode.Right);
            }
        }
    }
}