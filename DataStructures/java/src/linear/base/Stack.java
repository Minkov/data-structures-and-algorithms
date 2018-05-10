package linear.base;

public interface Stack<T> {
    void push(T value);

    T pop();

    T peek();

    int size();
}
