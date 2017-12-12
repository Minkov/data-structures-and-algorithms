const Queue = require('./data-structures/queue');

const queue = new Queue();

queue.enqueue(1)
    .enqueue(2)
    .enqueue(3)
    .enqueue(4);

while (!queue.isEmpty()) {
    console.log(queue.dequeue());
}
