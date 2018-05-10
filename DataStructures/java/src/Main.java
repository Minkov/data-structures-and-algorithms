import linear.ArrayStack;
import linear.LinkedStack;
import linear.base.Stack;

import java.util.stream.IntStream;

public class Main {

    public static void main(String[] args) {
        testStack(new ArrayStack<>());
        testStack(new LinkedStack<>());
    }

    static void testStack(Stack<Integer> stack) {
        IntStream.range(1, 10)
            .forEach(stack::push);

        while (stack.size() > 0) {
            System.out.println(stack.peek());
            stack.pop();
        }
    }
}
