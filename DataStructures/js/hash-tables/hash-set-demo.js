const HashSet = require('./data-structures/hash-set');

const set = new HashSet();

set.add(1);
set.add(1);
set.add(1);
set.add(1);
set.add(1);
set.add(1);

console.log(set);

console.log(set.contains(1));
console.log(set.contains(2));
set.add(2);
console.log(set.contains(2));
set.remove(1);
console.log(set.contains(1));

