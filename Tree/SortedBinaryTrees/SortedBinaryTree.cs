using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree.SortedBinaryTrees
{
    public class SortedBinaryTree<T> : ICollection<T> where T : IComparable
    {
        public List<BinaryTreeNode<T>> testList = new List<BinaryTreeNode<T>>();
        private int count;
        private BinaryTreeNode<T> root;

        public int Count
        {
            get { return this.count; }
        }
        public BinaryTreeNode<T> Root
        {
            get { return root; }
            set { root = value; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }

        public SortedBinaryTree()
        {
            
        }

        public void Add(T item)
        {
            this.count++;

            if (this.root == null)
            {
                this.root = new BinaryTreeNode<T>(item, this, null);
                return;
            }

            this.root.Insert(item);
        }

        public T Lowest()
        {
            return root.FindMinimum().TValue;
        }

        public T Heighest()
        {
            return root.FindMaximum().TValue;
        }

        public void Clear()
        {
            while (this.root != null)
            {
                count--;
                this.root.Dispose();
            }
        }

        public bool Contains(T item)
        {
            return root.Find(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            this.count--;
            return this.root.RemoveValue(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        [Serializable]
        public class DublicationException : Exception
        {
            public DublicationException() { }
            public DublicationException(string message) : base(message) { }
            public DublicationException(string message, Exception inner) : base(message, inner) { }
            protected DublicationException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
    }
}
