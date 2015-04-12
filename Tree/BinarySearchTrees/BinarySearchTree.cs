using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree.BinarySearchTrees
{
    public class BinarySearchTree<T> : ICollection<T>, IList<T> where T : IComparable
    {
        private int count;
        private BinarySearchNode<T> root;

        public int Count
        {
            get { return count; }
        }

        int ICollection<T>.Count
        {
            get { return this.count; }
        }

        public BinarySearchNode<T> Root
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
            get { return this.RecreateArray()[index]; }
            set { this[index] = value; }
        }

        public BinarySearchTree()
        {

        }

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

        public void Add(params T[] bulk)
        {
            foreach (var item in bulk)
            {
                this.Add(item);
            }
        }

        public void Insert(int index, T item)
        {
            var parent = root.Find(this[index]);
            parent.Insert(item);
        }

        public T Lowest()
        {
            return root.FindMinimum().Value;
        }

        public T Heighest()
        {
            return root.FindMaximum().Value;
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
            for (int i = 0; i < this.count; i++)
                if (this[i].Equals(item))
                    return i;

            return -1;
        }

        public bool Contains(T item)
        {
            return root.Contains(item);
        }

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

        public void CopyTo(T[] array)
        {
            this.CopyTo(array, 0);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            //pre-order traversal
            foreach (var item in root.Preorder())
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public void Balance()
        {
            var sorted = this.Sort();

            var trans = new Queue<T>();
            Unsort(sorted, trans, 0, sorted.Length - 1);

            this.Clear();

            while (trans.Count > 0)
            {
                this.Add(trans.Dequeue());
            }
        }

        private void Unsort(T[] array, Queue<T> trans, int start, int end)
        {
            int pivot = start + (end - start + 1) / 2;
            trans.Enqueue(array[pivot]);

            if (start < pivot )
            {
                Unsort(array, trans, start, pivot - 1);
            }
            if (pivot < end)
            {
                Unsort(array, trans, pivot + 1, end);
            }
        }

        private int Partition(T[] array, T[] trans, int start, int end)
        {
            int pivot = (end - start) / 2;

            return end;
        }


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

        public bool Remove(T item)
        {
            this.count--;

            return this.root.RemoveValue(item);
        }

        public void RemoveAt(int index)
        {
            this.Remove(this[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var nodes = new T[count];
            this.CopyTo(nodes);

            return new BinarySearchEnumerator<T>(nodes);
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
