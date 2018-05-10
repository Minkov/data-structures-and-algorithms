package linear;


import linear.base.Stack;

import java.util.Arrays;

public class ArrayStack<T> implements Stack<T> {
    private final static int DEFAULT_INITIAL_CAPACITY = 8;
    private Object[] values;
    private int capacity;
    private int size;

    public ArrayStack() {
        capacity = DEFAULT_INITIAL_CAPACITY;
        values = new Object[this.capacity];
        size = 0;
    }

    @Override
    public void push(T value) {
        if (size >= capacity) {
            resize();
        }

        values[size] = value;
        ++size;
    }

    @Override
    public T pop() {
        T valueToReturn = (T) values[size - 1];
        --size;

        return valueToReturn;
    }

    @Override
    public T peek() {
        return (T) values[size - 1];
    }

    @Override
    public int size() {
        return size;
    }

    private void resize() {
        values = Arrays.copyOf(values, capacity << 1);
        capacity <<= 1;
    }
}
