using System;
using System.Collections.Generic;

namespace Tree.SortedBinaryTrees
{
    public class BinaryTreeNode<T> : IDisposable where T : IComparable
    {
        private SortedBinaryTree<T> tree;

        public T TValue;

        public BinaryTreeNode<T> Parent;
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;

        public bool IsRoot
        {
            get { return Parent == null; }
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

        public BinaryTreeNode(T value, SortedBinaryTree<T> tree, BinaryTreeNode<T> parent)
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
                        this.Left = new BinaryTreeNode<T>(other, tree, this);
                        this.tree.testList.Add(this.Left);
                    }  
                    break;
                case 1:
                    if (this.Right != null)
                        this.Right.Insert(other);
                    else
                    {
                        this.Right = new BinaryTreeNode<T>(other, tree, this);
                        this.tree.testList.Add(this.Right);
                    }  
                    break;
                case 0:
                default:
                    break;
            }
        }

        public BinaryTreeNode<T> FindMinimum()
        {
            if (this.Left != null)
                return this.Left.FindMinimum();
            else
                return this;
        }

        public BinaryTreeNode<T> FindMaximum()
        {
            if (this.Right != null)
                return this.Right.FindMaximum();
            else
                return this;
        }

        public bool RemoveValue(T item)
        {
            switch (TValue.CompareTo(item))
            {
                case -1:
                    if (this.Left != null)
                        return false;
                    else
                        return this.Left.RemoveValue(item);
                case 0:
                    this.Dispose();
                    return true;
                case 1:
                    if (this.Right != null)
                        return false;
                    else
                        return this.Right.RemoveValue(item);
                default:
                    return false;
            }

        }

        public bool Find(T item)
        {
            switch (item.CompareTo(TValue))
            {
                case -1:
                    if (this.Left == null)
                        return false;
                    else
                        return Left.Find(item);
                case 0:
                    return true;
                case 1:
                    if (this.Right == null)
                        return false;
                    else
                        return Right.Find(item);
                default:
                    return false;
            }
        }

        public override string ToString()
        {
            string print = this.TValue.ToString();

            var temp = this;

            while (!temp.IsRoot)
            {
                print += " > " + temp.Parent.TValue;
                temp = temp.Parent;
            }

            return print;
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
                tree.testList.Remove(this);
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
    }
}
