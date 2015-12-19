namespace Trees
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class BinarySearchTree<T> : IEnumerable<T>, IBinarySearchTree<T> where T : IComparable<T>
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

        public T Min
        {
            get
            {
                return this.MinNode.Value;
            }
        }

        public T Max
        {
            get
            {
                var node = Root;
                if (node == null)
                {
                    throw new InvalidOperationException("No nodes in the tree");
                }
                while (node.Right != null)
                {
                    node = node.Right;
                }
                return node.Value;
            }
        }

        public int MaxCount { get; private set; }

        private BinarySearchTreeNode MinNode
        {
            get
            {
                var node = Root;
                if (node == null)
                {
                    throw new InvalidOperationException("No nodes in the tree");
                }
                while (node.Left != null)
                {
                    node = node.Left;
                }
                return node;
            }
        }

        public void Add(T g)
        {
            if (this.Root == null)
            {
                this.Root = new BinarySearchTreeNode
                {
                    Value = g
                };
                this.Count = 1;
                return;
            }
            this.Add(this.Root, g);
            ++this.Count;
        }

        public void Remove(T value)
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("Cannot remove elements from empty tree");
            }
            else if (!this.Contains(value))
            {
                throw new InvalidOperationException("Value not in tree");
            }
            else if (this.Count == 1)
            {
                this.Root = null;
                this.Count = 0;
                return;
            }

            --this.Count;
        }

        public bool Contains(T value)
        {
            return this.Contains(this.Root, value);
        }

        public IEnumerable<T> GetSmallerThan(T to)
        {
            return this.GetSmallerThan(to, false);
        }

        public IEnumerable<T> GetSmallerThan(T to, bool isExclusive)
        {
            var enumerator = this.GetNodeEnumerator();
            var result = new List<T>();
            while (enumerator.MoveNext())
            {
                if (isExclusive && enumerator.Current.Value.CompareTo(to) >= 0)
                {
                    break;
                }
                else if (!isExclusive && enumerator.Current.Value.CompareTo(to) > 0)
                {
                    break;
                }

                result.Add(enumerator.Current.Value);
            }
            return result;
        }

        public IEnumerable<T> GetBiggerThan(T from)
        {
            return this.GetBiggerThan(from, false);
        }

        public IEnumerable<T> GetBiggerThan(T from, bool isExclusive)
        {
            var enumerator = this.GetNodeEnumerator();
            var result = new List<T>();
            while (enumerator.MoveNext() && enumerator.Current.Value.CompareTo(from) < 0)
            {

            }

            do
            {
                if (isExclusive && enumerator.Current.Value.CompareTo(from) == 0)
                {
                    continue;
                }

                result.Add(enumerator.Current.Value);
            }
            while (enumerator.MoveNext());
            return result;
        }

        public IEnumerable<T> GetRangeBetween(T from, T to)
        {
            return this.GetRangeBetween(from, to, false);
        }

        public IEnumerable<T> GetRangeBetween(T from, T to, bool isExclusive)
        {

            var enumerator = this.GetNodeEnumerator();
            var result = new List<T>();
            while (enumerator.MoveNext() && enumerator.Current.Value.CompareTo(from) < 0)
            {
                ;
            }

            do
            {
                if (isExclusive && enumerator.Current.Value.CompareTo(from) == 0)
                {
                    continue;
                }
                if ((enumerator.Current.Value.CompareTo(to) > 0) || (isExclusive && enumerator.Current.Value.CompareTo(to) == 0))
                {
                    break;
                }

                result.Add(enumerator.Current.Value);
            }
            while (enumerator.MoveNext());
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var enumerator = this.GetNodeEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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

        private IEnumerator<BinarySearchTreeNode> GetNodeEnumerator()
        {
            var node = this.Root;

            var nodes = new Stack<BinarySearchTreeNode>();
            while (node != null || nodes.Count > 0)
            {
                if (node != null)
                {
                    nodes.Push(node);
                    node = node.Left;
                }
                else
                {
                    if (nodes.Count > 0)
                    {
                        node = nodes.Pop();
                        yield return node;
                        node = node.Right;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}