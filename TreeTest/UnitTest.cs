using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree.SortedBinaryTrees;

namespace TreeTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestSortedAdd()
        {
            var tree = new SortedBinaryTree<int>()
            {
                0, 1, 2, 3, 4, 5
            };

            Assert.AreEqual(6, tree.Count, "\nCounting the elements");
        }

        [TestMethod]
        public void TestSortedHighest()
        {
            var inttree = new SortedBinaryTree<int>() { 0, 1, 2, 3, 4, 5, 6 };
            var stringtree = new SortedBinaryTree<string>() { "hello", "test", "Case", "scenario" };
            var doubletree = new SortedBinaryTree<double>() { 74.24, 75.1, 1.75, 64.1, 2.535, 63.2, 1.4 };

            Assert.AreEqual(6, inttree.Heighest(), "\nHeighest int.");
            Assert.AreEqual("test", stringtree.Heighest(), "\nHeighest string.");
            Assert.AreEqual(75.1, doubletree.Heighest(), "\nHeighest double.");
        }

        [TestMethod]
        public void TestSortedLowest()
        {
            var inttree = new SortedBinaryTree<int>() { 0, 1, 2, 3, 4, 5, 6 };
            var stringtree = new SortedBinaryTree<string>() { "hello", "test", "Case", "scenario" };
            var doubletree = new SortedBinaryTree<double>() { 74.24, 75.1, 1.75, 64.1, 2.535, 63.2, 1.4 };

            Assert.AreEqual(0, inttree.Lowest(), "\nLowest int.");
            Assert.AreEqual("Case", stringtree.Lowest(), "\nLowest string.");
            Assert.AreEqual(1.4, doubletree.Lowest(), "\nLowest double.");
        }

        [TestMethod]
        public void TestSortedClear()
        {
            var tree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 25, 16 };

            tree.Clear();

            Assert.AreEqual(0, tree.Count, "\nTree counts no nodes.");
        }

        [TestMethod]
        public void TestSortedContain()
        {
            var tree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 25, 16 };

            Assert.IsTrue(tree.Contains(62), "\nFinding 43 in the tree.");
        }

        [TestMethod]
        public void TestSortedRemove()
        {
            var tree = new SortedBinaryTree<int>() { 40, 11, 62, 43, 34, 25, 16 };

            Assert.IsTrue(tree.Contains(40), "\nChecking if 43 is there.");
            Assert.IsTrue(tree.Remove(40), "\nRemoving 43.");
            Assert.IsFalse(tree.Contains(40), "\nChecking if 43 is still there.");
        }
    }
}
