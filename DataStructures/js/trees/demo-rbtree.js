const {
    RedBlackTree,
} = require('./data-structures/rbtree');


const tree = new RedBlackTree();


const vals = [2, 1, 2, 3, 100, 1, 5, 6, 7, -1, -1, -1, -2, ];
vals.forEach((val) => {
    tree.add(val);
});

console.log([...new Set(vals)].sort((x, y) => x - y));


console.log([...tree]);