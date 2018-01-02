// class HashSet {
//     constructor() {
//         this.values = [];
//     }

//     get size() {
//         return this.values.length;
//     }

//     add(value) {
//         if (this.values.includes(value)) {
//             return;
//         }

//         this.values.push(value);
//     }

//     remove(value) {
//         const index = this.values.indexOf(value);
//         if (index < 0) {
//             return;
//         }

//         this.values.splice(index, 1);
//     }

//     has(value) {
//         return this.values.includes(value);
//     }
// }

const EXPAND_COEFF = 0.7;

class HashSet {
    constructor(hashFunc, equalityFunc) {
        this.values = [];
        this.count = 0;
        this.capacity = 4;
        if (typeof hashFunc === 'undefined') {
            this.hashFunc = this._defaultHashFunc;
        } else {
            this.hashFunc = hashFunc;
        }

        this.equalityFunc = equalityFunc || this._defaultEqualityFunc;
    }

    add(value) {
        // get the hash of VALUE
        const hash = this._calcHash(value);

        if (typeof this.values[hash] === 'undefined') {
            this.values[hash] = [];
        }

        // if (this.values[hash].some((other) => this.equalityFunc(other, value))) {
        //     return this;
        // }

        // re-set if VALUE exists in VALUES
        const index = this.values[hash]
            .findIndex((other) => this.equalityFunc(other, value));

        if (index >= 0) {
            this.values[hash][index] = value;
            return this;
        }

        // else add VALUE to VALUES
        this.values[hash].push(value);
        this.count += 1;

        if (this._shouldExpand()) {
            this._expand();
        }

        return this;
    }

    has(value) {
        const hash = this._calcHash(value);

        if (typeof this.values[hash] === 'undefined') {
            return false;
        }

        return this.values[hash]
            .some((other) => this.equalityFunc(other, value));
    }

    remove(value) {
        const hash = this._calcHash(value);

        if (typeof this.values[hash] === 'undefined') {
            return this;
        }

        const index = this.values[hash]
            .findIndex((other) => this.equalityFunc(other, value));
        if (index < 0) {
            return this;
        }

        this.values[hash].splice(index, 1);
        this.count -= 1;
        return this;
    }

    _shouldExpand() {
        return this.capacity * EXPAND_COEFF <= this.count;
    }

    _expand() {
        this.capacity *= 2;
        const oldValues = this.values;
        this.values = [];

        // O(n)
        for (const subarr of oldValues) {
            if (typeof subarr === 'undefined') {
                continue;
            }

            for (const obj of subarr) {
                this.add(obj);
            }
        }
    }

    _calcHash(value) {
        return this.hashFunc(value) % this.capacity;
    }

    _defaultHashFunc(value) {
        let hash = 0;
        value.toString()
            .split('')
            .forEach((ch) => {
                hash *= 47;
                hash += ch.charCodeAt(0);
            });

        return Math.abs(hash);
    }
    _defaultEqualityFunc(x, y) {
        return x === y;
    }
}

/*
3
6
12

*/
/*
a * 9 + b * 3 + c
c * 9 + b * 3 + a
add, remove, check -> O(1)
*/
const hashFunc = (value) => {
    return value.id;
};

const equalityFunc = (x, y) => {
    return x.id === y.id;
};

const set = new HashSet(hashFunc, equalityFunc);
set.add({
    id: 1,
    a: 1,
});
set.add({
    id: 2,
    a: 1,
});

set.add({
    id: 1,
    a: 2,
});
console.log(set.values);
// set.add('John');
// // console.log(set.values);
// set.add('John');
// // console.log(set.values);
// set.add('Jane');
// // console.log(set.values);
// set.add('abc');
// // console.log(set.values);
// console.log('-'.repeat(10));
// set.add('cba');
// console.log(set.has('abc'));
// set.remove('abc');
// console.log(set.has('abc'));
// console.log(set.has('abd'));
// console.log(set.has('bac'));
// console.log(set.values);
// set.remove('John');
// console.log(set.values);
// console.log(set.has('John'));
// console.log(set.has('Jane'));

/*
0.7
'John' -> 5 % 4 = 1
'Jane' -> 6 % 4 = 2
'Stamat' -> 9 % 4 = 1
'Pesho' - > 7 % 4 = 3
'Gosho' -> 8 % 4 = 0
'Gencho' -> 26 % 4 = 2
'John' -> 5 % 4 = 1

| 0 | ['Gosho']
| 1 | ['John', 'Stamat']
| 2 | ['Jane', 'Gencho']
| 3 | ['Pesho']

'John' -> 5 % 8 = 5
'Jane' -> 6 % 8 = 6
'Stamat' -> 9 % 8 = 1
'Pesho' - > 7 % 8 = 7
'Gosho' -> 8 % 8 = 0
'Gencho' -> 26 % 8 = 2

| 0 | ['Gosho']
| 1 | ['Stamat']
| 2 | ['Gencho']
| 3 | []
| 4 | []
| 5 | ['John']
| 6 | ['Jane']
| 7 | ['Pesho']
*/