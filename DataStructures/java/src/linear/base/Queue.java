package linear.base;

public interface Queue<T> {
    void enqueue(T value);

    T dequeue();

    T peek();

    int size();

    boolean isEmpty();
}
