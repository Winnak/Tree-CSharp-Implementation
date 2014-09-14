using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree.BinarySearchTrees
{
    class BinarySearchEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        public T[] Nodes;
        private int position = -1;

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

        public BinarySearchEnumerator(T[] nodes)
        {
            this.Nodes = nodes;
        }

        public bool MoveNext()
        {
            position++;
            return position < this.Nodes.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            position = -1;
        }
    }
}
