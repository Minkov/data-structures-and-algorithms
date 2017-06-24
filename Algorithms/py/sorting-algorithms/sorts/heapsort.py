def swap(arr, i, j):
    tmp = arr[i]
    arr[i] = arr[j]
    arr[j] = tmp


def heapify_down(arr, index):
    left = 2 * index + 1
    right = 2 * index + 2

    if len(arr) <= left:
        return

    if len(arr) <= right:
        if arr[left] < arr[index]:
            swap(arr, index, left)
        return

    minIndex = left \
        if arr[left] < arr[right] \
        else right

    if arr[minIndex] < arr[index]:
        swap(arr, index, minIndex)
        heapify_down(arr, minIndex)


def sort(arr):
    heap = arr[:]
    for i in range(len(heap) - 1, -1, -1):
        heapify_down(heap, i)

    result = []
    while len(heap) > 0:
        result.append(heap[0])
        heap[0] = heap[-1]
        heap.pop()
        heapify_down(heap, 0)

    return result
