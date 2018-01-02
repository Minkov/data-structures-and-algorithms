from data_structures.rbtree import RedBlackTree

tree = RedBlackTree()


tree.add(5)
tree.add(2)
tree.add(3)
tree.add(3)
tree.add(3)
tree.add(3)

for val in tree:
    print(val)