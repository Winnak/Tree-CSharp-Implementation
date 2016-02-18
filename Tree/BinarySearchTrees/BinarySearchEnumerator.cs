using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees
{
    /// <summary>
    /// Enumerates the elements of a <see cref="BinarySearchTree"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the tree.</typeparam>
    internal class BinarySearchEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private T[] Nodes;
        private int position = -1;

        /// <summary>
        /// Gets the element at the current position of the enumerator.
        /// </summary>
        public T Current
        {
            get
            {
                try
                {
                    return this.Nodes[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        internal BinarySearchEnumerator(T[] nodes)
        {
            this.Nodes = nodes;
        }

        /// <summary>
        /// Moves the position.
        /// </summary>
        /// <returns><c>True</c> if it is within dataset; otherwise <c>false</c>.</returns>
        public bool MoveNext()
        {
            position++;
            return position < this.Nodes.Length;
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            position = -1;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            position = -1;
        }
    }
}
