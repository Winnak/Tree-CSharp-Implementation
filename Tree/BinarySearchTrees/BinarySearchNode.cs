using System;
using System.Collections.Generic;

namespace Tree.BinarySearchTrees
{
    /// <summary>
    /// Represents a node in a strongly typed tree of objects. 
    /// </summary>
    /// <typeparam name="T">The type of elements in the node.</typeparam>
    internal class BinarySearchNode<T> : IDisposable where T : IComparable
    {
        private BinarySearchTree<T> tree;

        private T TValue;

        private BinarySearchNode<T> parent;
        private BinarySearchNode<T> left;
        private BinarySearchNode<T> right;

        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        public T Value
        {
            get { return TValue; }
            set { TValue = value; }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="BinarySearchNode"/>.
        /// </summary>
        public BinarySearchNode<T> Parent
        {
            get {  return parent; }
            private set { parent = value; }
        }

        /// <summary>
        /// Gets or sets the left <see cref="BinarySearchNode"/> child.
        /// </summary>
        public BinarySearchNode<T> Left
        {
            get { return left; }
            private set { left = value; }
        }

        /// <summary>
        /// Gets or sets the right <see cref="BinarySearchNode"/> child.
        /// </summary>
        public BinarySearchNode<T> Right
        {
            get { return right; }
            private set { right = value; }
        }

        /// <summary>
        /// Gets if the <see cref="BinarySearchNode"/> is the root node.
        /// </summary>
        public bool IsRoot
        {
            get { return Parent == null && this == this.tree.root; }
        }

        /// <summary>
        /// Gets if the <see cref="BinarySearchNode"/> is a leaf node. 
        /// </summary>
        public bool IsLeaf
        {
            get { return Left == null && Right == null; }
        }

        /// <summary>
        /// Gets if the <see cref="BinarySearchNode"/> has any children.
        /// </summary>
        public bool HasChildren
        {
            get { return Left != null || Right != null; }
        }

        /// <summary>
        /// Gets if the <see cref="BinarySearchNode"/> has just one child.
        /// </summary>
        public bool HasSingleChild
        {
            get { return Left != null ^ Right != null; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchNode"/> class,
        /// with a value and connected to a tree.
        /// </summary>
        /// <param name="value">The value for this element.</param>
        /// <param name="tree">The tree this is connected to.</param>
        /// <param name="parent">The node's parent, can be null.</param>
        public BinarySearchNode(T value, BinarySearchTree<T> tree, BinarySearchNode<T> parent)
        {
            this.Parent = parent;
            this.TValue = value;
            this.tree = tree;
        }

        /// <summary>
        /// Tries to inserts an element into this <see cref="BinarySearchNode"/>.
        /// </summary>
        /// <remarks>Looks through its children in case it cannot insert into this <see cref="BinarySearchNode"/>.</remarks>
        /// <param name="other">The element to be inserted.</param>
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

        /// <summary>
        /// Looks through its children to find the lowest value child.
        /// </summary>
        /// <returns>The lowest value stored in the <see cref="BinarySearchTree"/>.</returns>
        public BinarySearchNode<T> FindMinimum()
        {
            if (this.Left != null)
                return this.Left.FindMinimum();
            else
                return this;
        }

        /// <summary>
        /// Looks through its children to find the highest value child.
        /// </summary>
        /// <returns>The highest value stored in the <see cref="BinarySearchTree"/>.</returns>
        public BinarySearchNode<T> FindMaximum()
        {
            if (this.Right != null)
                return this.Right.FindMaximum();
            else
                return this;
        }

        /// <summary>
        /// Looks through its children to find the child with the target value, and removes it.
        /// </summary>
        /// <param name="item">Proposed value of a node in the <see cref="BinarySearchTree"/>.</param>
        /// <returns><c>True</c> if the value is in the <see cref="BinarySearchTree"/>; otherwise <c>false</c>.</returns>
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

        /// <summary>
        /// Determines whether an element is in the <see cref="BinarySearchNode"/> or its children.
        /// </summary>
        /// <param name="item">The object to locate.</param>
        /// <returns><c>True</c> if item is found in the <see cref="BinarySearchNode"/> or its children; otherwise, <c>false</c>.</returns>
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

        /// <summary>
        /// Searches for a <see cref="BinarySearchNode"/> that matches the conditions defined by the specified value, and returns the first occurrence within this <see cref="BinarySearchNode"/> and its children.
        /// </summary>
        /// <param name="match">The value of the element to search for.</param>
        /// <returns>The <see cref="BinarySearchNode"/> containing the value.</returns>
        public BinarySearchNode<T> Find(T match)
        {
            switch (this.TValue.CompareTo(match))
            {
                case -1:
                    if (this.Left == null)
                        throw new InvalidNodeException(string.Format("Item {0} was not found in the tree", match));
                    else
                        return Left.Find(match);
                case 0:
                    return this;
                case 1:
                    if (this.Right == null)
                        throw new InvalidNodeException(string.Format("Item {0} was not found in the tree", match));
                    else
                        return Right.Find(match);
                default:
                    throw new InvalidNodeException(string.Format("Item {0} was not found in the tree", match));
            }
        }

        /// <summary>
        /// Exposes the enumerator, which uses pre order traversal over the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection in pre order.</returns>
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

        /// <summary>
        /// Exposes the enumerator, which uses in order traversal over the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection in in order.</returns>
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

        /// <summary>
        /// Exposes the enumerator, which uses post order traversal over the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection in post order.</returns>
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

        /// <summary>
        /// Exposes the enumerator, which uses level order traversal over the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection in level order.</returns>
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

        /// <summary>
        /// Disposes of this <see cref="BinarySearchNode"/> and its children.
        /// </summary>
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
                    tree.root = null;
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
