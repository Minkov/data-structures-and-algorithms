package linear;

import linear.base.Stack;

public class LinkedStack<T> implements Stack<T> {

    private Node<T> top;
    private int size;

    public LinkedStack() {
        top = null;
        size = 0;
    }

    @Override
    public void push(T value) {
        Node<T> node = new Node<>(value);
        if (top == null) {
            top = node;
        } else {
            top.setNext(node);
            node.setPrev(top);
            top = top.getNext();
        }
        ++size;
    }

    @Override
    public T pop() {
        T valueToReturn = top.getValue();
        top = top.getPrev();
        --size;
        return valueToReturn;
    }

    @Override
    public T peek() {
        return top.getValue();
    }

    @Override
    public int size() {
        return size;
    }

    class Node<V> {
        private Node<V> next;
        private Node<V> prev;
        private V value;

        Node(V value) {
            this.value = value;
            next = null;
            prev = null;
        }

        Node<V> getPrev() {
            return prev;
        }

        void setPrev(Node<V> prev) {
            this.prev = prev;
        }

        Node<V> getNext() {
            return next;
        }

        void setNext(Node<V> next) {
            this.next = next;
        }

        V getValue() {
            return value;
        }

        public void setValue(V value) {
            this.value = value;
        }
    }
}
