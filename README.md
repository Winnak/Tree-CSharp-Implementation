# Trees C# implementation 
*(Currently just BST)*
I did this just for fun.

##TODO:
* Downgrade solution file.
* Switch unittest from VS' test suite to NUnit.
* Try heap trees.

##Benchmark:
```
System.Generic.List<int> took: 444 ticks to add 20000 elements.
System.Generic.List<int> took: 137 ticks to add 20000 elements (with count reserved).
System.Generic.List<int> took: 206 ticks to find '17927' in the list.
System.Generic.List<int> took:  58 ticks to clear.
 
Tree.BinarySearchTrees.BinarySearchTree<int> took: 19384856 ticks to add 20000 elements.
Tree.BinarySearchTrees.BinarySearchTree<int> took: 	   1265 ticks to find '17927' in the BST.
Tree.BinarySearchTrees.BinarySearchTree<int> took: 10531144 ticks to balance.
Tree.BinarySearchTrees.BinarySearchTree<int> took:        3 ticks to find '17927' in the balanced BST.
Tree.BinarySearchTrees.BinarySearchTree<int> took:     3798 ticks to clear.
```
So in conclusion, this is slower that just using .Net's List<T>, which also supports duplicates. 

Note: With more elements balancing the BST will throw a StackOverflowException.
