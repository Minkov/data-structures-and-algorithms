#include<iostream>

namespace data_structures {
#include "linked_list.cpp"

template<class T>
class Queue {
public:

    Queue();

    void enqueue(T);

    T dequeue();

    T peek();

    unsigned int getSize();
    bool isEmpty();
private:
    data_structures::LinkedList<T> *list;
};


template<class T>
Queue<T>::Queue() {
    this->list = new data_structures::LinkedList<T>();
}

template<class T>
void Queue<T>::enqueue(T value) {
    this->list->addTail(value);
}

template<class T>
T Queue<T>::dequeue() {
    T value = this->list->getHead();
    this->list->removeHead();
    return value;
}

template<class T>
T Queue<T>::peek() {
    return this->list->getHead();
}

template<class T>
unsigned int Queue<T>::getSize() {
    return this->list->getSize();
}

template<class T>
bool Queue<T>::isEmpty() {
    return (this->getSize()) == 0;
}

}