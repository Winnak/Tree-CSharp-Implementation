using System;
using System.Diagnostics;

namespace Trees
{
    [Serializable, DebuggerDisplay("Count = {Count}")]
    public class RedBlackTree<T> where T : IComparable
    {
        private int count;
        internal RedBlackTreeNode<T> root;

        /// <summary>
        /// Gets the number of elements contained in the <see cref="RedBlackTree{T}"/>.
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Gets or sets the root node of the tree.
        /// </summary>
        public T Root
        {
            get { return root.Value; }
        }

        /// <summary>
        /// It does nothing.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Inserts an element into the <see cref="RedBlackTree{T}"/> at the specified index.
        /// </summary>
        /// <remarks>Does not allow duplicates.</remarks>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        public void Insert(int index, T value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="RedBlackTree{T}"/>.
        /// </summary>
        /// <remarks>Does not allow duplicates.</remarks>
        /// <param name="item">The object to be added to the end of the <see cref="RedBlackTree{T}"/>.</param>
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specific object from the <see cref="RedBlackTree{T}"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="RedBlackTree{T}"/>.</param>
        /// <returns><c>True</c> if value was in the <see cref="RedBlackTree{T}"/>; 
        /// otherwise <c>false</c>.</returns>
        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all values stored in the <see cref="RedBlackTree{T}"/>.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
