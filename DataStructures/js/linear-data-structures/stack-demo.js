const Stack = require('./data-structures/stack');

const expression = '(123 * (1 + 3) + ((4 - 3) / 6))';
const getSubExpressions = (exp) => {
    const stack = new Stack();

    const subExpressions = [];

    exp.split('')
        .forEach((ch, index) => {
            if (ch === '(') {
                stack.push(index);
            } else if (ch === ')') {
                const first = stack.pop();
                const last = index;
                subExpressions.push(exp.substring(first, last + 1));
            }
        });

    return subExpressions;
};

getSubExpressions(expression)
    .forEach((subExp) => console.log(subExp));