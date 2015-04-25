# Trees C# implementation 
*(Currently just BST)*
I did this just for fun.

##TODO:
* Downgrade solution file.
* Switch unittest from VS' test suite to NUnit.
* Try heap trees.

##Benchmark:
```
Tree.BinarySearchTrees.BinarySearchTree<int> took: 19384856 ticks to add 20000 elements.
Tree.BinarySearchTrees.BinarySearchTree<int> took: 	   1265 ticks to find '17927' in the BST.
Tree.BinarySearchTrees.BinarySearchTree<int> took: 10531144 ticks to balance.
Tree.BinarySearchTrees.BinarySearchTree<int> took:        3 ticks to find '17927' in the balanced BST.
Tree.BinarySearchTrees.BinarySearchTree<int> took:     3798 ticks to clear.
```
Note: With more elements balancing the BST will throw a StackOverflowException.
