class Stack {
    constructor() {
        this.vals = [];
    }

    get count() {
        return this.vals.length;
    }

    push(...values) {
        values.forEach((val) => this.vals.push(val));
        return this;
    }

    pop() {
        const val = this.vals[this.vals.length - 1];

        this.vals = this.vals.slice(0, this.vals.length - 1);

        return val;
    }

    peek() {
        return this.vals[this.vals.length - 1];
    }

    isEmpty() {
        return this.count === 0;
    }
}

module.exports = Stack;