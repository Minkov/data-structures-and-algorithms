const LinkedList = require('./data-structures/linked-list');

const printList = (theList) => {
    const line = [];
    for (const val of theList) {
        line.push(val);
    }

    console.log(line.join(', '));
};

const list = new LinkedList();
list.addLast(1)
    .addLast(2)
    .addLast(3)
    .addLast(4);

list.addFirst(-1);
list.addFirst(3);

printList(list);

console.log('-'.repeat(30));
console.log(list.removeFirst());
printList(list);

console.log(list.removeLast());
printList(list);