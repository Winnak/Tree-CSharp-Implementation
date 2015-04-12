using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tree.BinarySearchTrees
{
    [SerializableAttribute]
    [DebuggerDisplayAttribute("Count = {Count}")]
    /// <summary>
    /// Represents a strongly typed tree of objects that can be accessed by index. 
    /// Provides methods sort, and manipulate tree.
    /// </summary>
    /// <remarks>Does not allow duplicates.</remarks>
    /// <typeparam name="T">The type of elements in the tree.</typeparam>
    public class BinarySearchTree<T> : ICollection<T>, IList<T> where T : IComparable
    {
        private int count;
        private BinarySearchNode<T> root;

        /// <summary>
        /// Gets the number of elements contained in the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Gets or sets the root node of the tree.
        /// </summary>
        public BinarySearchNode<T> Root
        {
            get { return root; }
            set { root = value; }
        }

        /// <summary>
        /// It does nothing.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted..</param>
        /// <returns>The element.</returns>
        public T this[int index]
        {
            get { return this.RecreateArray()[index]; }
            set { this[index] = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree<T>"/> class that is empty.
        /// </summary>
        public BinarySearchTree()
        {

        }

        /// <summary>
        /// Adds an object to the end of the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <remarks>Does not allow duplicates.</remarks>
        /// <param name="item">The object to be added to the end of the <see cref="BinarySearchTree<T>"/>.</param>
        public void Add(T item)
        {
            this.count++;

            if (this.root == null)
            {
                this.root = new BinarySearchNode<T>(item, this, null);
                return;
            }

            this.root.Insert(item);
        }

        /// <summary>
        /// Adds the object(s) to the end of the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <remarks>Does not allow duplicates.</remarks>
        /// <param name="bulk">The object to be added to the end of the <see cref="BinarySearchTree<T>"/>.</param>
        public void Add(params T[] bulk)
        {
            foreach (var item in bulk)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Inserts an element into the <see cref="BinarySearchTree<T>"/> at the specified index.
        /// </summary>
        /// <remarks>Does not allow duplicates.</remarks>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        public void Insert(int index, T item)
        {
            var parent = root.Find(this[index]);
            parent.Insert(item);
        }

        /// <summary>
        /// Finds the lowest value stored in the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <returns>The lowest value.</returns>
        public T Lowest()
        {
            return root.FindMinimum().Value;
        }
        
        /// <summary>
        /// Finds the highest value stored in the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <returns>The highest value.</returns>
        public T Heighest()
        {
            return root.FindMaximum().Value;
        }

        /// <summary>
        /// Removes all values stored in the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        public void Clear()
        {
            while (this.root != null)
            {
                count--;
                this.root.Dispose();
            }
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index 
        /// of the first occurrence within the entire <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="BinarySearchTree<T>"/>.</param>
        /// <returns>he zero-based index of the first occurrence of item within the entire <see cref="BinarySearchTree<T>"/>, if found; otherwise, –1.</returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < this.count; i++)
                if (this[i].Equals(item))
                    return i;

            return -1;
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="BinarySearchTree<T>"/>.</param>
        /// <returns><c>True</c> if item is found in the <see cref="BinarySearchTree<T>"/>; otherwise, <c>false</c>.</returns>
        public bool Contains(T item)
        {
            return root.Contains(item);
        }

        /// <summary>
        /// Creates an array with the value stored in the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <returns>An array with the values in preorder.</returns>
        private T[] RecreateArray()
        {
            var preOrderTraversal = new T[count];
            int index = 0;

            foreach (var item in root.Preorder())
            {
                preOrderTraversal[index] = item;
                index++;
            }

            return preOrderTraversal;
        }

        /// <summary>
        /// Copies the entire <see cref="BinarySearchTree<T>"/> to a compatible one-dimensional array, 
        /// starting at the beginning of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from <see cref="BinarySearchTree<T>"/>. 
        /// The Array must have zero-based indexing.</param>
        public void CopyTo(T[] array)
        {
            this.CopyTo(array, 0);
        }

        /// <summary>
        /// Copies the entire <see cref="BinarySearchTree<T>"/> to a compatible one-dimensional array, 
        /// starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from <see cref="BinarySearchTree<T>"/>. 
        /// The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            //pre-order traversal
            foreach (var item in root.Preorder())
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        /// <summary>
        /// Copies a range of elements from the <see cref="BinarySearchTree<T>"/> to a compatible one-dimensional array, 
        /// starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from <see cref="BinarySearchTree<T>"/>. 
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <param name="count">The number of elements to copy.</param>
        public void CopyTo(T[] array, int arrayIndex, int count)
        {
            //pre-order traversal
            int i = 0;
            foreach (var item in root.Preorder())
            {
                array[arrayIndex] = item;
                arrayIndex++;

                i++;
                if (i >= count)
                    break;
            }
        }

        /// <summary>
        /// Balances the <see cref="BinarySearchTree<T>"/>.
        /// <remarks>Appends lowest first.</remarks>
        /// </summary>
        public void Balance()
        {
            var sorted = this.Sort();

            var medianQueue = new Queue<T>();
            FindMedians(sorted, medianQueue, 0, sorted.Length - 1);

            this.Clear();

            while (medianQueue.Count > 0)
            {
                this.Add(medianQueue.Dequeue());
            }
        }

        /// <summary>
        /// Used by Balance() to recursivly find the median and add it to a <see cref="Queue<T>"/>.
        /// </summary>
        /// <param name="array">A one-dimensional Array with all the values in sorted order.</param>
        /// <param name="medianQueue"><see cref="Queue<T>"/> of medians in the optimal order.</param>
        /// <param name="start">Left bound.</param>
        /// <param name="end">Right bound.</param>
        private void FindMedians(T[] array, Queue<T> medianQueue, int start, int end)
        {
            int pivot = start + (end - start + 1) / 2;
            medianQueue.Enqueue(array[pivot]);

            if (start < pivot )
            {
                FindMedians(array, medianQueue, start, pivot - 1);
            }
            if (pivot < end)
            {
                FindMedians(array, medianQueue, pivot + 1, end);
            }
        }

        /// <summary>
        /// Sorts the elements in the entire <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <returns>Array of sorted elements.</returns>
        public T[] Sort()
        {
            var sorted = new T[this.count];
            int index = 0;

            foreach (var item in root.Inorder())
            {
                sorted[index] = item;
                index++;
            }

            return sorted;
        }

        /// <summary>
        /// Removes the specific object from the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="BinarySearchTree<T>"/>.</param>
        /// <returns><c>True</c> if value was in the <see cref="BinarySearchTree<T>"/>; 
        /// otherwise <c>false</c>.</returns>
        public bool Remove(T item)
        {
            this.count--;

            return this.root.RemoveValue(item);
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public void RemoveAt(int index)
        {
            this.Remove(this[index]);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <returns>A <see cref="BinarySearchEnumerator<T>"/> for the <see cref="BinarySearchTree<T>"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var nodes = new T[count];
            this.CopyTo(nodes);

            return new BinarySearchEnumerator<T>(nodes);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="BinarySearchTree<T>"/>.
        /// </summary>
        /// <returns>A <see cref="BinarySearchEnumerator<T>"/> for the <see cref="BinarySearchTree<T>"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}
