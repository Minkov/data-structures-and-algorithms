class HashMap {
    constructor(hashFunc, equalsFunc) {
        this.values = {};
        this.count = 0;
        this.hashFunc = hashFunc || ((key) => key.toString());
        this.equalsFunc = equalsFunc || ((k1, k2) => k1 === k2);
    }

    set(key, value) {
        const keyHash = this.hashFunc(key);
        if (typeof this.values[keyHash] === 'undefined') {
            this.values[keyHash] = [];
        }
        const keyIndex = this.values[keyHash].findIndex(([k, _]) => this.equalsFunc(k, key));
        if (keyIndex > 0) {
            this.values[keyIndex] = [key, value];
        } else {
            this.values[keyHash].push([key, value]);
        }

        this.count += 1;
        return this;
    }

    get(key) {
        const keyHash = this.hashFunc(key);
        if (typeof this.values[keyHash] === 'undefinded') {
            return null;
        }

        const [_, value] = this.values[keyHash].find(([k, _]) => this.equalsFunc(k, key)) || [null, null];
        return value;
    }

    contains(key) {
        const keyHash = this.hashFunc(key);
        if (typeof this.values[keyHash] === 'undefined') {
            return false;
        }

        return !!(this.values[keyHash].find(([k, _]) => this.equalsFunc(k, key)));
    }

    remove(key) {
        const keyHash = this.hashFunc(key);
        if (typeof this.values[keyHash] === 'undefined') {
            return this;
        }

        const index = this.values[keyHash].findIndex(([k, _]) => this.equalsFunc(k, key));
        if (index >= 0) {
            this.values[keyHash].splice(index, 1);
        }
        
        return this;
    }
}

module.exports = HashMap;