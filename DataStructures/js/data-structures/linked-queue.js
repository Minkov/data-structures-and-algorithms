/* globals Symbol */

const LinkedList = require('./linked-list');

class Queue {
    constructor() {
        this.list = new LinkedList();
    }

    enqueue(...values) {
        this.list.addLast(values);
        return this;
    }

    dequeue() {
        return this.list.removeFirst();
    }

    peek() {
        return this.list.head;
    }

    isEmpty() {
        return this.list.isEmpty();
    }
}

module.exports = Queue;