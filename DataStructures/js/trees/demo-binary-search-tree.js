const BinarySearchTree = require('./data-structures/binary-tree');

const tree = new BinarySearchTree();

console.log(tree.isBalanced);
tree.add(1);
console.log(tree.isBalanced);
tree.add(2);
console.log(tree.isBalanced);
tree.add(3);
console.log(tree.isBalanced);
tree.add(4);
console.log(tree.isBalanced);
tree.add(-11);
console.log(tree.isBalanced);
tree.add(-5);
console.log(tree.isBalanced);
tree.add(-12);
console.log(tree.isBalanced);

tree.inOrder();
console.log(` --- Min: ${tree.min} ---`);
console.log(` --- Max: ${tree.max} ---`);
console.log(` --- Contains: ${tree.contains(1)} ---`);
console.log(` --- Contains: ${tree.contains(5)} ---`);