const defaultCompareFunc = (x, y) => {
    return x <= y;
};

const defaultEqualsFunc = (x, y) => {
    return x === y;
};

class BinarySearchTree {
    constructor(compareFunc, equalsFunc) {
        this.root = null;
        this.compareFunc = compareFunc || defaultCompareFunc;
        this.equalsFunc = equalsFunc || defaultEqualsFunc;
    }

    get min() {
        return this.getMin();
    }

    get max() {
        return this.getMax();
    }

    add(value) {
        const newNode = {
            value,
            left: null,
            right: null,
        };

        if (this.root === null) {
            this.root = newNode;
        } else {
            this._addTraverse(this.root, newNode);
        }
    }

    contains(value) {
        return this._containsTraverse(this.root, value);
    }

    inOrder() {
        if (this.root === null) {
            return;
        }

        this._inOrder(this.root);
    }

    getMin() {
        if (this.root === null) {
            return null;
        }

        let node = this.root;
        while (node.left !== null) {
            node = node.left;
        }

        return node.value;
    }

    getMax() {
        if (this.root === null) {
            return null;
        }

        let node = this.root;
        while (node.right !== null) {
            node = node.right;
        }

        return node.value;
    }

    _inOrder(node) {
        if (node.left !== null) {
            this._inOrder(node.left);
        }
        console.log(node.value);
        if (node.right !== null) {
            this._inOrder(node.right);
        }
    }

    _addTraverse(node, newNode) {
        if (this.compareFunc(newNode.value, node.value)) {
            if (node.left === null) {
                node.left = newNode;
            } else {
                this._addTraverse(node.left, newNode);
            }
        } else {
            if (node.right === null) {
                node.right = newNode;
            } else {
                this._addTraverse(node.right, newNode);
            }
        }
    }

    _containsTraverse(node, value) {
        if (node === null) {
            return false;
        }

        if (this.equalsFunc(node.value, value)) {
            return true;
        }
        if (this.compareFunc(value, node.value)) {
            return this._containsTraverse(node.left, value);
        }

        return this._containsTraverse(node.right, value);
    }

    _getHeight(node) {
        if (!node) return 0;
        const leftHeight = this._getHeight(node.left);
        const rightHeight = this._getHeight(node.right);

        return Math.max(leftHeight, rightHeight) + 1;
    }
}

module.exports = BinarySearchTree;
