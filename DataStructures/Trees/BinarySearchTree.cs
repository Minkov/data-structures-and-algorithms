namespace Trees
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        class BinarySearchTreeNode
        {
            public T Value { get; set; }
            public BinarySearchTreeNode Left { get; set; }
            public BinarySearchTreeNode Right { get; set; }
            public BinarySearchTreeNode Parent { get; set; }
        }

        BinarySearchTreeNode Root { get; set; }

        public int Count { get; private set; }

        public void Add(T g)
        {
            if (this.Root == null)
            {
                this.Root = new BinarySearchTreeNode
                {
                    Value = g
                };
                return;
            }
            this.Add(this.Root, g);
        }

        private void Add(BinarySearchTreeNode node, T g)
        {
            if (node.Value.CompareTo(g) >= 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinarySearchTreeNode()
                    {
                        Value = g,
                        Parent = node
                    };
                }
                else
                {
                    this.Add(node.Left, g);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinarySearchTreeNode()
                    {
                        Value = g,
                        Parent = node
                    };
                }
                else
                {
                    this.Add(node.Right, g);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var nodes = new Stack<BinarySearchTreeNode>();
            var current = this.Root;
            while (current != null || nodes.Count > 0)
            {
                if (current != null)
                {
                    nodes.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (nodes.Count > 0)
                    {
                        current = nodes.Pop();
                        yield return current.Value;
                        current = current.Right;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Contains(T value)
        {
            return this.Contains(this.Root, value);
        }

        private bool Contains(BinarySearchTreeNode node, T value)
        {
            if (node == null)
            {
                return false;
            }
            if (node.Value.CompareTo(value) == 0)
            {
                return true;
            }
            if (node.Value.CompareTo(value) > 0)
            {
                return this.Contains(node.Left, value);
            }
            else
            {
                return this.Contains(node.Right, value);
            }
        }

        public void Remove(T value)
        {
            throw new NotImplementedException();
        }
    }
}