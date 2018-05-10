/* globals Map, Set */

const Queue = require('../linear-data-structures/data-structures/queue');

class Graph {
    constructor() {
        this._nodes = new Map();
    }

    addEdge(x, y) {
        this.addDirectedEdge(x, y);
        this.addDirectedEdge(y, x);
    }

    addWeightedEdge(x, y, w) {
        this.addDirectedWeightedEdge(x, y, w);
        this.addDirectedWeightedEdge(x, y, w);
    }

    addDirectedEdge(from, to) {
        if (!this._nodes.has(from)) {
            this._nodes.set(from, []);
        }
        this._nodes.get(from).push(to);
    }

    addDirectedWeightedEdge(from, to, weight) {
        if (!this._nodes.has(from)) {
            this._nodes.set(from, []);
        }

        this._nodes.get(from).push({
            vertex: to,
            weight,
        });
    }

    dfs(from) {
        const paths = new Map();
        paths.set(from, -1);

        const dfsInternal = (vertex, used) => {
            this._nodes[vertex].forEach((next) => {
                if (used.has(next)) {
                    return;
                }

                used.add(next);
                paths.set(next, vertex);
                dfsInternal(next, used);
            });
        };
        dfsInternal(from, new Set());

        const path = this._constructPath(from, paths);
        return path;
    }

    allDfs(v, used) {
        this._nodes.get(v)
            .filter((next) => !used.has(next))
            .forEach((next) => {
                used.add(next);
                this.allDfs(next, used);
                used.delete(next);
            });
    }

    bfs(from) {
        const queue = new Queue();
        const used = new Set();

        queue.enqueue(from);
        used.add(from);
        const path = new Map();
        path.set(from, -1);

        while (!queue.isEmpty()) {
            const top = queue.dequeue();

            this._nodes[top]
                .filter((next) => !used.has(next))
                .forEach((next) => {
                    used.add(next);
                    path.set(next, top);
                    queue.enqueue(next);
                });
        }

        return this._constructPath(from, path);
    }

    _constructPath(from, paths) {
        const path = [];
        const vertex = from;
        while (vertex !== -1) {
            path.push(vertex);
            path = paths.get(path);
        }

        return path.reverse();
    }
};