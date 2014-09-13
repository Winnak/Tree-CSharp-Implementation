using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree.SortedBinaryTrees;

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
        public void TestSortedAdd()
        {
            var tree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
            tree.Add(3);
            Assert.AreEqual(9, tree.Count, "\nCounting the elements");
        }

        [TestMethod]
        public void TestSortedHighest()
        {
            var inttree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
            var stringtree = new SortedBinaryTree<string>() { "hello", "test", "Case", "scenario" };
            var doubletree = new SortedBinaryTree<double>() { 74.24, 75.1, 1.75, 64.1, 2.535, 63.2, 1.4 };

            Assert.AreEqual(63, inttree.Heighest(), "\nHeighest int.");
            Assert.AreEqual("test", stringtree.Heighest(), "\nHeighest string.");
            Assert.AreEqual(75.1, doubletree.Heighest(), "\nHeighest double.");
        }

        [TestMethod]
        public void TestSortedLowest()
        {
            var inttree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
            var stringtree = new SortedBinaryTree<string>() { "hello", "test", "Case", "scenario" };
            var doubletree = new SortedBinaryTree<double>() { 74.24, 75.1, 1.75, 64.1, 2.535, 63.2, 1.4 };

            Assert.AreEqual(10, inttree.Lowest(), "\nLowest int.");
            Assert.AreEqual("Case", stringtree.Lowest(), "\nLowest string.");
            Assert.AreEqual(1.4, doubletree.Lowest(), "\nLowest double.");
        }

        [TestMethod]
        public void TestSortedClear()
        {
            var tree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };

            tree.Clear();

            Assert.AreEqual(0, tree.Count, "\nTree counts no nodes.");
        }

        [TestMethod]
        public void TestSortedContain()
        {
            var tree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };

            Assert.IsTrue(tree.Contains(62), "\nFinding 43 in the tree.");
        }

        [TestMethod]
        public void TestSortedRemove()
        {
            var tree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };

            Assert.IsTrue(tree.Contains(43), "\nChecking if 43 is there.");
            Assert.IsTrue(tree.Remove(43), "\nRemoving 43.");
            Assert.IsFalse(tree.Contains(43), "\nChecking if 43 is still there.");
        }

        [TestMethod]
        public void TestSortedCopyTo()
        {
            var tree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 16, 10, 63 };
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
    }
}
