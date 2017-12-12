/* globals Symbol */

class LinkedList {
    constructor() {
        this.head = null;
        this.tail = null;
        this.count = 0;
    }

    addLast(...values) {
        if (values.length > 1) {
            values.forEach(this.pushFront);
            return this;
        }

        const node = {
            value: values[0],
            next: null,
            prev: null,
        };

        if (this.head === null) {
            this.head = node;
            this.tail = node;
        } else {
            this.tail.next = node;
            node.prev = this.tail;
            this.tail = this.tail.next;
        }

        this.count += 1;

        return this;
    }

    addFirst(...values) {
        if (values.length > 1) {
            values.forEach(this.pushFront);
            return this;
        }
        const node = {
            value: values[0],
            next: null,
            prev: null,
        };

        if (this.head === null) {
            this.head = node;
            this.tail = node;
        } else {
            this.head.prev = node;
            node.next = this.head;
            this.head = this.head.prev;
        }

        this.count += 1;

        return this;
    }

    removeFirst() {
        if (this.head === null) {
            return null;
        }
        this.count -= 1;

        const value = this.head.value;
        this.head = this.head.next;

        if (this.head === null) {
            this.head = null;
            this.tail = null;
            return value;
        }

        this.head.prev = null;

        return value;
    }

    removeLast() {
        if (this.tail === null) {
            return null;
        }

        this.count -= 1;

        const value = this.tail.value;
        this.tail = this.tail.prev;

        if (this.tail === null) {
            this.head = null;
            this.tail = null;
            return value;
        }

        this.tail.next = null;
        return value;
    }

    isEmpty() {
        return this.count === 0;
    }

    [Symbol.iterator]() {
        let node = this.head;

        function* iterator() {
            while (node !== null) {
                yield node.value;
                node = node.next;
            }
        }

        return iterator();
    }
}

module.exports = LinkedList;