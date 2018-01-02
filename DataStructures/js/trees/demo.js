const Heap = require('./data-structures/heap');

const heap = new Heap();

heap.add(5);
heap.add(4);
heap.add(3);
heap.add(2);
heap.add(1);
heap.add(5);
heap.add(5);
heap.add(5);
heap.add(5);

console.log(heap);

heap.remove();
heap.add(1);

while (heap.count > 0) {
    console.log(heap.top);
    heap.remove();
}