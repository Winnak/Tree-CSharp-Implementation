using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree.BinarySearchTrees;

namespace TreeTest
{
    [TestClass]
    public class UnitTest
    {
        // The int tree
        //               40
        //            /      \
        //          11        62
        //         /  \      /  \
        //       10   34   43    63
        //           /
        //         16

        [TestMethod]
        public void TestBSTAdd()
        {
            var tree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
            tree.Add(3);
            Assert.AreEqual(9, tree.Count, "\nCounting the elements");
        }

        [TestMethod]
        public void TestBSTHighest()
        {
            var inttree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
            var stringtree = new BinarySearchTree<string>() { "hello", "test", "Case", "scenario" };
            var doubletree = new BinarySearchTree<double>() { 74.24, 75.1, 1.75, 64.1, 2.535, 63.2, 1.4 };

            Assert.AreEqual(63, inttree.Heighest(), "\nHeighest int.");
            Assert.AreEqual("test", stringtree.Heighest(), "\nHeighest string.");
            Assert.AreEqual(75.1, doubletree.Heighest(), "\nHeighest double.");
        }

        [TestMethod]
        public void TestBSTLowest()
        {
            var inttree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
            var stringtree = new BinarySearchTree<string>() { "hello", "test", "Case", "scenario" };
            var doubletree = new BinarySearchTree<double>() { 74.24, 75.1, 1.75, 64.1, 2.535, 63.2, 1.4 };

            Assert.AreEqual(10, inttree.Lowest(), "\nLowest int.");
            Assert.AreEqual("Case", stringtree.Lowest(), "\nLowest string.");
            Assert.AreEqual(1.4, doubletree.Lowest(), "\nLowest double.");
        }

        [TestMethod]
        public void TestBSTClear()
        {
            var tree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };

            tree.Clear();

            Assert.AreEqual(0, tree.Count, "\nTree counts no nodes.");
        }

        [TestMethod]
        public void TestBSTContain()
        {
            var tree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };

            Assert.IsTrue(tree.Contains(62), "\nFinding 43 in the tree.");
        }

        [TestMethod]
        public void TestBSTRemove()
        {
            var tree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };

            Assert.IsTrue(tree.Contains(43), "\nChecking if 43 is there.");
            Assert.IsTrue(tree.Remove(43), "\nRemoving 43.");
            Assert.IsFalse(tree.Contains(43), "\nChecking if 43 is still there.");
        }

        [TestMethod]
        public void TestBSTCopyTo()
        {
            var tree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
            int[] actual = new int[tree.Count];
            int[] expected = new int[] { 40, 11, 10, 34, 16, 62, 43, 63 };

            int[] actual2 = new int[tree.Count + 2];
            int[] expected2 = new int[] { 0, 0, 40, 11, 10, 34, 16, 62, 43, 63 };

            tree.CopyTo(actual);
            tree.CopyTo(actual2, 2);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i], "\nFailed at [" + i + "]");

            for (int i = 2; i < expected2.Length; i++)
                Assert.AreEqual(expected2[i], actual2[i], "\nFailed at [" + i + "]");
        }

        [TestMethod]
        public void TestBSTIndexOf()
        {
            var tree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };

            Assert.AreEqual(0, tree.IndexOf(tree.Root.Value), "Checking that root is in the 0. place.");
            Assert.AreEqual(4, tree.IndexOf(16), "Checking 16 is in the 4. place.");
        }

        [TestMethod]
        public void TestBSTRemoveAt()
        {
            var tree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };

            Assert.AreEqual(34, tree[3], "Checking that 34 is on the 3. place in the array.");
            tree.RemoveAt(3);
            Assert.IsFalse(tree.Contains(34), "Checking if 34 is in the tree.");
        }

        [TestMethod]
        public void TestBSTEnumerator()
        {
            var tree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
            int[] expected = new int[] { 40, 11, 10, 34, 16, 62, 43, 63 };

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], tree[i], "Checkin {0} place of tree.", i);
            }
        }

        [TestMethod]
        public void TestBSTSort()
        {
            var tree = new BinarySearchTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
            int[] expected = new int[]{ 10, 11, 16, 34, 40, 43, 62, 63 };

            var sorted = tree.Sort();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], sorted[i], "Checkin {0} place of tree.", i);
            }
        }
    }
}
