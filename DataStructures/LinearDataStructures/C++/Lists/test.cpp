#include <iostream>
#include "linked_list.cpp"

int main() {
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
