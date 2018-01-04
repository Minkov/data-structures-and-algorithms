const Queue = require('./data-structures/queue');

const queue = new Queue();

queue.enqueue(1)
    .enqueue(2)
    .enqueue(3)
    .enqueue(4);

console.log('-'.repeat(50));
for (const val of queue) {
    console.log(val);
}
console.log('-'.repeat(50));

while (!queue.isEmpty()) {
    console.log(queue.dequeue());
}

queue.enqueue(5);

while (!queue.isEmpty()) {
    console.log(queue.dequeue());
}