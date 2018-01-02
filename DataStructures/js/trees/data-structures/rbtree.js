const BLACK = 0;
const RED = 1;
const NO_COLOR = 2;

class Node {
    constructor(value, color, parent, left = null, right = null) {
        this.value = value;
        this.color = color;
        this.parent = parent;
        this.left = left;
        this.right = right;
    }

    get childrenCount() {
        const count =
            (this.right !== null) ? 1 : 0 +
            (this.left !== null) ? 1 : 0;
        return count;
    }

    hasChildren() {
        return this.childrenCount > 0;
    }

    *[Symbol.iterator]() {
        if (this.left.color !== NO_COLOR) {
            for (const val of this.left) {
                yield val;
            }
        }

        yield this.value;

        if (this.right.color !== NO_COLOR) {
            for (const val of this.right) {
                yield val;
            }
        }
    }
}

class RedBlackTree {
    constructor() {
        this.count = 0;
        this.root = null;
        this.rotations = {
            'L': this._rightRotation,
            'R': this._leftRoration,
        };

        this.nullLeaf = new Node(null, NO_COLOR, null)
    }

    add(value) {
        if (this.root === null) {
            this.root =
                new Node(value, BLACK, null, this.nullLeaf, this.nullLeaf);
            this.count += 1;
            return this;
        }

        const {
            parent,
            nodeDir,
        } = this._findParent(value);

        if (nodeDir === null) {
            return this;
        }

        const newNode =
            new Node(value, RED, parent, this.nullLeaf, this.nullLeaf);
        if (nodeDir === 'L') {
            parent.left = newNode;
        } else {
            parent.right = newNode;
        }

        this._tryRebalance(newNode);
        this.count += 1;

        return this;
    }

    remove(value) {
        /**
        Try to get a node with 0 or 1 children.
        Either the node we're given has 0 or 1 children or we get its successor.
        **/
        const nodeToremove = this._findNode(value);
        if (nodeToremove === null) { // # node is not in the tree
            return this;
        }

        if (nodeToremove.childrenCount === 2) {
            // find the in-order successor and replace its value.
            // then, remove the successor
            const successor = this._findInOrderSuccessor(nodeToremove);
            nodeToremove.value = successor.value; // switch the value
            nodeToremove = successor;
        }

        // has 0 or 1 children!
        self._remove(nodeToremove);
        self.count -= 1;

        return this;
    }

    *[Symbol.iterator]() {
        if (this.root !== null) {
            for (const val of this.root) {
                yield val;
            }
        }
    }
    _tryRebalance(node) {
        /*
        Given a red child node, determine if there is a need
        to rebalance (if the parent is red)
        If there is, rebalance it
        */
        const {
            parent,
            value,
        } = node;

        if (parent === null ||
            parent.parent === null ||
            (node.color !== RED || parent.color !== RED)) {
            return;
        }

        const grandfather = parent.parent;
        const nodeDir = parent.value > value ?
            'L' :
            'R';
        const parentDir = grandfather.value > parent.value ?
            'L' :
            'R';
        const uncle = parentDir === 'L' ?
            grandfather.right :
            grandfather.left;

        const generalDirection = nodeDir + parentDir;

        if (uncle === this.nullLeaf || uncle.color === BLACK) {
            if (generalDirection === 'LL') {
                this._rightRoratation(node, parent, grandfather, true);
            } else if (generalDirection === 'RR') {
                this._leftRotation(node, parent, grandfather, true);
            } else if (generalDirection === 'LR') {
                this._rightRoratation(null, node, parent);
                // due to the prev rotation, our node is now the parent
                this._leftRotation(parent, node, grandfather, true);
            } else if (generalDirection === 'RL') {
                this._leftRotation(null, node, parent);
                // due to the prev rotation, our node is now the parent
                this._rightRoratation(parent, node, grandfather, true);
            } else {
                const errorMessage =
                    `${generalDirection} is not a valid direction!`;
                throw new Error(errorMessage);
            }
        } else { // uncle is RED
            this._recolor(grandfather);
        }
    }

    _rightRoratation(node, parent, grandfather, toRecolor = false) {
        const grandGrandfather = grandfather.parent;
        this._updateParent(parent, grandfather, grandGrandfather);

        const oldRight = parent.right;
        parent.right = grandfather;
        grandfather.parent = parent;

        grandfather.left = oldRight; // save the old right values
        oldRight.parent = grandfather;

        if (toRecolor) {
            parent.color = BLACK;
            node.color = RED;
            grandfather.color = RED;
        }
    }

    _leftRotation(node, parent, grandfather, toRecolor = false) {
        const grandGrandfather = grandfather.parent;
        this._updateParent(parent, grandfather, grandGrandfather);

        const oldLeft = parent.left;
        parent.left = grandfather;
        grandfather.parent = parent;

        grandfather.right = oldLeft;
        oldLeft.parent = grandfather;

        if (toRecolor) {
            parent.color = BLACK;
            node.color = RED;
            grandfather.color = RED;
        }
    }

    _findParent(value) {
        // Finds a place for the value in our binary tree
        const innerFind = (parent) => {
            /**
            Return the appropriate parent node for our new node
            as well as the side it should be on
            **/
            if (value === parent.value) {
                return {
                    parent: null,
                    nodeDir: null,
                };
            } else if (parent.value < value) {
                if (parent.right.color === NO_COLOR) {
                    return {
                        parent,
                        nodeDir: 'R',
                    };
                }
                return innerFind(parent.right);
            } else if (value < parent.value) {
                if (parent.left.color === NO_COLOR) {
                    return {
                        parent,
                        nodeDir: 'L',
                    };
                }
                return innerFind(parent.left);
            }

            return {
                parent: null,
                nodeDir: null,
            };
        };

        return innerFind(this.root);
    }

    _findNode(value) {
        const innerFind = (root) => {
            if (root === null || root === this.nullLeaf) {
                return null;
            }
            if (value > root.value) {
                return innerFind(root.right);
            } else if (value < root.value) {
                return innerFind(root.left);
            }
            return root;
        };

        const foundNode = innerFind(self.root);
        return foundNode;
    }

    _findInOrderSuccessor(node) {
        const rightNode = node.right;
        let leftNode = rightNode.left;
        if (leftNode === this.nullLeaf) {
            return rightNode;
        }

        while (leftNode.left !== this.nullLeaf) {
            leftNode = leftNode.left;
        }

        return leftNode;
    }

    _recolor(grandfather) {
        grandfather.right.color = BLACK;
        grandfather.left.color = BLACK;
        if (grandfather !== this.root) {
            grandfather.color = RED;
        }

        this._tryRebalance(grandfather);
    }

    _updateParent(node, parentOldChild, newParent) {
        /**
        Our node 'switches' places with the old child
        Assigns a new parent to the node.
        If the new_parent is None,
        this means that our node becomes the root of the tree
        **/
        node.parent = newParent;
        if (newParent) {
            // Determine the old child's position in order to put node there
            if (newParent.value > parentOldChild.value) {
                newParent.left = node;
            } else {
                newParent.right = node;
            }
        } else {
            this.root = node;
        }
    }
}

module.exports = {
    RedBlackTree,
};