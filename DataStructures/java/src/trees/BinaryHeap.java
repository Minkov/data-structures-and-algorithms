package trees;

import java.util.ArrayList;
import java.util.List;

public class BinaryHeap<T extends Comparable<T>> {
    public final List<T> values;
    private int size;

    public BinaryHeap() {
        values = new ArrayList<>();
        size = 0;
    }

    public void push(T value) {
        values.add(value);
        ++size;
        heapifyUp();
    }

    public T pop() {
        T value = values.get(0);

        values.set(0, values.get(values.size() - 1));
        values.remove(values.size() - 1);

        heapifyDown();
        return value;
    }

    public T peek() {
        return values.get(0);
    }

    public int size() {
        return size;
    }

    public boolean isEmpty() {
        return size() == 0;
    }


    private void heapifyDown() {
        int index = 0;
        while (index < values.size()) {
            boolean hasFoundSmaller = false;
            int newIndex = index;

            for (int i = 1; i <= 2; i++) {
                int nextIndex = (2 * index) + i;
                if (nextIndex >= values.size()) {
                    continue;
                }

                if (values.get(newIndex).compareTo(values.get(nextIndex)) > 0) {
                    newIndex = nextIndex;
                    hasFoundSmaller = true;
                }
            }
            if (hasFoundSmaller) {
                swap(index, newIndex);
                index = newIndex;
            } else {
                break;
            }
        }
    }

    private void heapifyUp() {
        int index = values.size() - 1;
        while (index > 0) {
            int parentIndex = (index - 1) / 2;
            if (values.get(index).compareTo(values.get(parentIndex)) < 0) {
                swap(index, parentIndex);
                index = parentIndex;
            } else {
                break;
            }
        }
    }

    private void swap(int i, int j) {
        T tmp = values.get(i);
        values.set(i, values.get(j));
        values.set(j, tmp);
    }
}
