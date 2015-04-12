using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree.BinarySearchTrees
{
    public class BinarySearchNode<T> : IDisposable where T : IComparable
    {
        private BinarySearchTree<T> tree;

        private T TValue;

        private BinarySearchNode<T> parent;
        private BinarySearchNode<T> left;
        private BinarySearchNode<T> right;

        public T Value
        {
            get { return TValue; }
            set { TValue = value; }
        }

        public BinarySearchNode<T> Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public BinarySearchNode<T> Left
        {
            get { return left; }
            set { left = value; }
        }

        public BinarySearchNode<T> Right
        {
            get { return right; }
            set { right = value; }
        }

        public bool IsRoot
        {
            get { return Parent == null && this.tree.Root == this; }
        }
        public bool IsLeaf
        {
            get { return Left == null && Right == null; }
        }
        public bool HasChildren
        {
            get { return Left != null || Right != null; }
        }
        public bool HasSingleChild
        {
            get { return Left != null ^ Right != null; }
        }

        public BinarySearchNode(T value, BinarySearchTree<T> tree, BinarySearchNode<T> parent)
        {
            this.Parent = parent;
            this.TValue = value;
            this.tree = tree;
        }

        public void Insert(T other)
        {
            switch (other.CompareTo(this.TValue))
            {
                case -1:
                    if (this.Left != null)
                        this.Left.Insert(other);
                    else
                    {
                        this.Left = new BinarySearchNode<T>(other, tree, this);
                    }  
                    break;
                case 1:
                    if (this.Right != null)
                        this.Right.Insert(other);
                    else
                    {
                        this.Right = new BinarySearchNode<T>(other, tree, this);
                    }  
                    break;
                case 0:
                default:
                    break;
            }
        }

        public BinarySearchNode<T> FindMinimum()
        {
            if (this.Left != null)
                return this.Left.FindMinimum();
            else
                return this;
        }

        public BinarySearchNode<T> FindMaximum()
        {
            if (this.Right != null)
                return this.Right.FindMaximum();
            else
                return this;
        }

        public bool RemoveValue(T item)
        {
            switch (item.CompareTo(TValue))
            {
                case -1:
                    if (this.Left == null)
                        return false;
                    else
                        return this.Left.RemoveValue(item);
                case 0:
                    this.Dispose();
                    return true;
                case 1:
                    if (this.Right == null)
                        return false;
                    else
                        return this.Right.RemoveValue(item);
                default:
                    return false;
            }

        }

        public bool Contains(T item)
        {
            switch (item.CompareTo(TValue))
            {
                case -1:
                    if (this.Left == null)
                        return false;
                    else
                        return Left.Contains(item);
                case 0:
                    return true;
                case 1:
                    if (this.Right == null)
                        return false;
                    else
                        return Right.Contains(item);
                default:
                    return false;
            }
        }

        public BinarySearchNode<T> Find(T item)
        {
            switch (this.TValue.CompareTo(item))
            {
                case -1:
                    if (this.Left == null)
                        throw new InvalidNodeException(string.Format("Item {0} was not found in the tree", item));
                    else
                        return Left.Find(item);
                case 0:
                    return this;
                case 1:
                    if (this.Right == null)
                        throw new InvalidNodeException(string.Format("Item {0} was not found in the tree", item));
                    else
                        return Right.Find(item);
                default:
                    throw new InvalidNodeException(string.Format("Item {0} was not found in the tree", item));
            }
        }

        public IEnumerable<T> Preorder()
        {
            yield return Value;
            if (Left != null)
                foreach (var value in Left.Preorder())
                    yield return value;
            if (Right != null)
                foreach (var value in Right.Preorder())
                    yield return value;
        }

        public IEnumerable<T> Inorder()
        {
            if (Left != null)
                foreach (var value in Left.Inorder())
                    yield return value;
            yield return Value;
            if (Right != null)
                foreach (var value in Right.Inorder())
                    yield return value;
        }

        public IEnumerable<T> Postorder()
        {
            if (Left != null)
                foreach (var value in Left.Postorder())
                    yield return value;
            if (Right != null)
                foreach (var value in Right.Postorder())
                    yield return value;
            yield return Value;
        }

        public IEnumerable<T> LevelOrder()
        {
            var queue = new Queue<BinarySearchNode<T>>();
            queue.Enqueue(this);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;
                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }

        public void Dispose()
        {
            if (IsLeaf)
            {
                if (!IsRoot)
                {
                    if (this.Parent.Left == this)
                        this.Parent.Left = null;

                    if (this.Parent.Right == this)
                        this.Parent.Right = null;

                    this.Parent = null;
                }
                else
                {
                    tree.Root = null;
                }
            }
            else
            {
                if (this.Left != null)
                {
                    var node = this.Left.FindMaximum();
                    this.TValue = node.TValue;
                    node.Dispose();
                }
                else if(this.Right != null)
                {
                    var node = this.Right.FindMinimum();
                    this.TValue = node.TValue;
                    node.Dispose();
                }
            }
        }

        [Serializable]
        public class InvalidNodeException : Exception
        {   
            public InvalidNodeException() { }
            public InvalidNodeException(string message) : base(message) { }
            public InvalidNodeException(string message, Exception inner) : base(message, inner) { }
            protected InvalidNodeException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
    }
}
