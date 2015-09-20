namespace data_structures {

template <class T>
struct LinkedListNode {
    T value;
    LinkedListNode<T> *next;
    LinkedListNode<T> *prev;

    LinkedListNode(T value): value(value), next(nullptr), prev(nullptr) {
    };
};

template <class T>
class LinkedList {
public:
    LinkedList();
    // ~LinkedList();

    unsigned int getSize();
    T getHead();
    T getTail();

    void addHead(T value);
    void addTail(T value);


private:
    unsigned int size;
    LinkedListNode<T> *head;
    LinkedListNode<T> *tail;
};

template <class T>
LinkedList<T>::LinkedList() {
    this->head = nullptr;
    this->tail = nullptr;
    this->size = 0;
}

template <class T>
void LinkedList<T>::addHead(T value) {
    LinkedListNode<T> *node = new LinkedListNode<T>(value);

    if (this->head == nullptr) {
        this->head = node;
        this->tail = node;
    }
    else {
        this->head->prev = node;
        node->next = this->head;
        this->head = node;
    }
    ++this->size;
}

template <class T>
void LinkedList<T>::addTail(T value) {
    LinkedListNode<T> *node = new LinkedListNode<T>(value);

    if (this->tail == nullptr) {
        this->head = node;
        this->tail = node;
    }
    else {
        this->tail->next = node;
        node->prev = this->tail;
        this->tail = node;
    }
    ++this->size;
}

template <class T>
T LinkedList<T>::getHead() {
    return this->head->value;
}

template <class T>
T LinkedList<T>::getTail() {
    return this->tail->value;
}
template <class T>
unsigned int LinkedList<T>::getSize() {
    return this->size;
}

}