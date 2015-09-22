#include <iostream>
#include "linked_list.cpp"
#include "queue.cpp"

void testList() {
    data_structures::LinkedList<int> list;
    int count = 15;
    for (int i = 0; i < count; i ++) {
        list.addTail(i + 1);
        std::cout << "Head: " << list.getHead()
                  << ", Tail: " << list.getTail()
                  << ", Size: " << list.getSize()
                  << std::endl;
    }
}

void testQueue() {
    data_structures::Queue<int> queue;
    int count = 15;
    for (int i = 0; i < count; i ++) {
        queue.enqueue(i + 1);
    }
    while (!queue.isEmpty()) {
        int val = queue.dequeue();
        std::cout << val << std::endl;
    }
}


int main() {

    std::cout << "Queue:" << std::endl;
    testQueue();

    std::cout << "List:" << std::endl;
    testList();

}
