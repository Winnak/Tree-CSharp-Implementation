using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree.SortedBinaryTrees
{
    public class SortedBinaryTree<T> : ICollection<T>, IList<T> where T : IComparable
    {
        private int count;
        private BinaryTreeNode<T> root;
        private T[] preOrderTraversal;

        public int Count
        {
            get { return count; }
        }
        int ICollection<T>.Count
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

        public T this[int index]
        {
            get { return preOrderTraversal[index]; }
            set { preOrderTraversal[index] = value; }
        }

        public SortedBinaryTree()
        {
            preOrderTraversal = new T[count];
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

            this.RecreateArray();
        }

        public void Insert(int index, T item)
        {
            var parent = root.Find(this.preOrderTraversal[index]);
            parent.Insert(item);
            this.RecreateArray();
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

        public int IndexOf(T item)
        {
            for (int i = 0; i < preOrderTraversal.Length; i++)
                if (preOrderTraversal[i].Equals(item))
                    return i;

            return -1;
        }

        public bool Contains(T item)
        {
            return root.Contains(item);
        }

        public void RecreateArray()
        {
            //pre-order traversal
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(null);

            var temp = root;
            int i = 0;

            preOrderTraversal = new T[count];

            while (temp != null)
            {
                preOrderTraversal[i] = temp.TValue;

                if (temp.Right != null)
                    stack.Push(temp.Right);

                if (temp.Left != null)
                    stack.Push(temp.Left);

                temp = stack.Pop();
                i++;
            }
        }

        public void CopyTo(T[] array)
        {
            this.CopyTo(array, 0);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            //pre-order traversal
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(null);

            var temp = root;
            int i = arrayIndex;

            while (temp != null)
            {
                array[i] = temp.TValue;

                if (temp.Right != null)
                    stack.Push(temp.Right);

                if (temp.Left != null)
                    stack.Push(temp.Left);

                temp = stack.Pop();
                i++;
            }
        }

        public bool Remove(T item)
        {
            this.count--;

            return this.root.RemoveValue(item);
        }

        public void RemoveAt(int index)
        {
            this.Remove(preOrderTraversal[index]);
            this.RecreateArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var nodes = new T[count];
            this.CopyTo(nodes);

            return new SortedBinaryEnumerator<T>(nodes);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
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
