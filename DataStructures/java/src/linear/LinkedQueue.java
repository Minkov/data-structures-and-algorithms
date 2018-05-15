package linear;

import linear.base.Queue;

public class LinkedQueue<T> implements Queue<T> {
    int size;
    private Node<T> tail;
    private Node<T> head;

    public LinkedQueue() {
        size = 0;
        head = null;
        tail = null;
    }

    @Override
    public void enqueue(T value) {
        Node<T> node = new Node<>(value);
        if (head == null) {
            head = node;
            tail = node;
        } else {
            tail.setNext(node);
            node.setPrev(tail);
            tail = tail.getNext();
        }
        ++size;
    }

    @Override
    public T dequeue() {
        T value = head.getValue();
        head = head.getNext();
        --size;
        return value;
    }

    @Override
    public T peek() {
        return head.getValue();
    }

    @Override
    public int size() {
        return size;
    }

    @Override
    public boolean isEmpty() {
        return size == 0;
    }

    class Node<V> {
        private V value;
        private Node<V> prev;
        private Node<V> next;

        Node(V value) {
            setValue(value);
            setPrev(null);
            setNext(null);
        }

        V getValue() {
            return value;
        }

        void setValue(V value) {
            this.value = value;
        }

        Node<V> getPrev() {
            return prev;
        }

        void setPrev(Node<V> prev) {
            this.prev = prev;
        }

        Node<V> getNext() {
            return prev;
        }

        void setNext(Node<V> next) {
            this.prev = next;
        }
    }
}
