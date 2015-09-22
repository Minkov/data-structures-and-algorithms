namespace data_structures {
#include<iostream>

template<class T>
class Stack {
public:
    Stack();
    ~Stack();

    void push(T);
    T pop();
    T peek();

    bool isEmpty();

    unsigned int getSize();

private:
    LinkedList<T> *list;
};


template<class T> Stack<T>::Stack() {
    this->list = new LinkedList<T>();
}

template<class T> Stack<T>::~Stack() {
    delete this->list;
}

template<class T>
void Stack<T>::push(T value) {
    this->list->addTail(value);
}

template<class T>
T Stack<T>::pop() {
    T value = this->list->getTail();
    this->list->removeTail();
    return value;
}

template<class T>
T Stack<T>::peek() {
    return this->list->getTail();
}

template<class T>
unsigned  int  Stack<T>::getSize() {
    return this->list->getSize();
}

template<class T>
bool Stack<T>::isEmpty() {
    return this->getSize() == 0;
}

}
