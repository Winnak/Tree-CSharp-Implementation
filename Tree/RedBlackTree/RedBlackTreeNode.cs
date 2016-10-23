using System;

namespace Trees
{
    internal class RedBlackTreeNode<T> : IDisposable where T : IComparable
    {
        private readonly RedBlackTree<T> tree;

        private T TValue;

        private RedBlackTreeNode<T> parent;
        private RedBlackTreeNode<T> left;
        private RedBlackTreeNode<T> right;

        private bool isBlack;
        
        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        public T Value
        {
            get { return TValue; }
            set { TValue = value; }
        }

        /// <summary>
        /// Gets or sets the parent <see cref="RedBlackTreeNode{T}"/>.
        /// </summary>
        public RedBlackTreeNode<T> Parent
        {
            get { return parent; }
            private set { parent = value; }
        }

        /// <summary>
        /// Gets or sets the left <see cref="RedBlackTreeNode{T}"/> child.
        /// </summary>
        public RedBlackTreeNode<T> Left
        {
            get { return left; }
            private set { left = value; }
        }

        /// <summary>
        /// Gets or sets the right <see cref="RedBlackTreeNode{T}"/> child.
        /// </summary>
        public RedBlackTreeNode<T> Right
        {
            get { return right; }
            private set { right = value; }
        }

        /// <summary>
        /// Gets if the <see cref="RedBlackTreeNode{T}"/> is the root node.
        /// </summary>
        public bool IsRoot
        {
            get { return Parent == null && this == this.tree.root; }
        }

        /// <summary>
        /// Gets if the <see cref="RedBlackTreeNode{T}"/> is a leaf node. 
        /// </summary>
        public bool IsLeaf
        {
            get { return Left == null && Right == null; }
        }

        /// <summary>
        /// Gets if the <see cref="RedBlackTreeNode{T}"/> has any children.
        /// </summary>
        public bool HasChildren
        {
            get { return Left != null || Right != null; }
        }

        /// <summary>
        /// Gets if the <see cref="RedBlackTreeNode{T}"/> has just one child.
        /// </summary>
        public bool HasSingleChild
        {
            get { return Left != null ^ Right != null; }
        }

        /// <summary>
        /// Gets if the <see cref="RedBlackTreeNode{T}"/> is black or red.
        /// </summary>
        public bool IsBlack
        {
            get { return isBlack; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RedBlackTreeNode{T}"/> class,
        /// as (probably) the root, with a value and connected to a tree.
        /// </summary>
        /// <param name="value">The value for this element.</param>
        /// <param name="tree">The tree this is connected to.</param>
        public RedBlackTreeNode(T item, RedBlackTree<T> tree)
        {
            this.TValue = item;
            this.tree = tree;
            this.parent = null;
            this.isBlack = true;
        }

        public void RotateLeft()
        {
            if (this.Right == null)
            {
                return;
            }

            var other = this.Right;
            this.Right = other.Left;
            if (other.Left != null)
            {
                other.Left.Parent = this;
            }
            other.Parent = this.Parent;
            if (this.Parent == null)
            {
                this.tree.root = other;
            }
            else if (this == this.Parent.Left)
            {
                this.Parent.Left = other;
            }
            else
            {
                this.Parent.Right = other;
            }
            other.Left = this;
            this.Parent = other;
        }

        public void RotateRight()
        {
            if (this.Left == null)
            {
                return;
            }

            var other = this.Left;
            this.Left = other.Right;
            if (other.Right != null)
            {
                other.Right.Parent = this;
            }
            other.Parent = this.Parent;
            if (this.Parent == null)
            {
                this.tree.root = other;
            }
            else if (this == this.Parent.Right)
            {
                this.Parent.Right = other;
            }
            else
            {
                this.Parent.Left = other;
            }
            other.Right = this;
            this.Parent = other;
        }

        /// <summary>
        /// Tries to inserts an element into this <see cref="RedBlackTreeNode{T}"/>.
        /// </summary>
        /// <remarks>Looks through its children in case it cannot insert into this <see cref="RedBlackTreeNode{T}"/>.</remarks>
        /// <param name="other">The element to be inserted.</param>
        public void Insert(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disposes of this <see cref="RedBlackTreeNode{T}"/> and its children.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
