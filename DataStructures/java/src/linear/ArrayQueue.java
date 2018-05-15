package linear;

import linear.base.Queue;

public class ArrayQueue<T> implements Queue<T> {
    private final static int INITIAL_CAPACITY = 8;
    private int size;
    private Object[] values;
    private int head;
    private int tail;

    public ArrayQueue() {
        values = new Object[INITIAL_CAPACITY];
        size = 0;
        head = 0;
        tail = -1;
    }

    @Override
    public void enqueue(T value) {
        if (size() >= values.length) {
            resize();
        }

        ++tail;
        tail = (tail + values.length) % values.length;
        values[tail] = value;
        ++size;
    }


    @Override
    public T dequeue() {
        T valueToReturn = (T) values[head];
        --head;
        --size;
        head = (head + values.length) % values.length;
        return valueToReturn;
    }

    @Override
    public T peek() {
        return (T) values[head];
    }

    @Override
    public int size() {
        return size;
    }

    @Override
    public boolean isEmpty() {
        return size() == 0;
    }


    private void resize() {
        Object[] oldValues = values;
        int oldHead = head;
        int oldTail = tail;

        values = new Object[values.length << 1];
        head = 0;
        tail = -1;
        size = 0;

        while (oldHead != oldTail) {
            enqueue((T) oldValues[oldHead]);
            ++oldHead;
            oldHead = (oldHead + oldValues.length) % oldValues.length;
        }
    }
}
