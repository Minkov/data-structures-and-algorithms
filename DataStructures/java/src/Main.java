import linear.base.Queue;
import linear.base.Stack;
import trees.BinaryHeap;

import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class Main {
    public static void main(String[] args) {
        testHeap(new BinaryHeap<Integer>());
//        testStack(new ArrayStack<>());
//        testStack(new LinkedStack<>());
//
//        testQueue(new LinkedQueue<>());
//        testQueue(new ArrayQueue<>());
    }

    private static void testHeap(BinaryHeap<Integer> heap) {
        int[] values = IntStream.range(1, 15)
            .map(x -> 15 - x)
            .toArray();
        for (int val : values) {
            heap.push(val);
            print(heap.values);
        }
        System.out.println("-----");

        while (!heap.isEmpty()) {
            System.out.println(heap.pop());
        }
    }

    private static void testQueue(Queue<Integer> queue) {
        System.out.println("-----------");
        IntStream.range(1, 10)
            .forEach(queue::enqueue);

        while (!queue.isEmpty()) {
            System.out.println(queue.dequeue());
        }

        System.out.println("-----------");
    }

    private static void testStack(Stack<Integer> stack) {
        System.out.println("-----------");
        IntStream.range(1, 10)
            .forEach(stack::push);

        while (stack.size() > 0) {
            System.out.println(stack.peek());
            stack.pop();
        }
        System.out.println("-----------");
    }

    static void print(List<Integer> list) {
        System.out.println(list.stream()
            .map(Object::toString)
            .collect(Collectors.joining(", "))
        );
    }

}
