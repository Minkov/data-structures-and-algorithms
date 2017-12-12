const HashMap = require('./data-structures/hash-map');

const map = new HashMap(null, (x, y) => x == y);

map.set('1', 4);
map.set('2', 3);

console.log(map.values);
console.log(map.get('1'));
console.log(map.get(1));
console.log(map.get('2'));

console.log(map.contains('2'));
console.log(map.contains('3'));
map.remove('2');
console.log(map.contains('2'));



