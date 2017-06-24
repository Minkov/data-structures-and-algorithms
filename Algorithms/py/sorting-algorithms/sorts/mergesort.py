def sort(arr):
    mergesort(arr, 0, len(arr), [None] * len(arr))
    return arr


def mergesort(arr, left, right, temp):
    if left >= right - 1:
        return

    middle = (left + right) // 2
    mergesort(arr, left, middle, temp)
    mergesort(arr, middle, right, temp)

    merge(arr, left, right, temp)


def merge(arr, left, right, temp):
    middle = (left + right) // 2
    leftIndex = left
    rightIndex = middle
    index = left

    while leftIndex < middle and rightIndex < right:
        if arr[leftIndex] <= arr[rightIndex]:
            temp[index] = arr[leftIndex]
            leftIndex += 1
        else:
            temp[index] = arr[rightIndex]
            rightIndex += 1
        index += 1

    while leftIndex < middle:
        temp[index] = arr[leftIndex]
        index += 1
        leftIndex += 1

    while rightIndex < right:
        temp[index] = arr[rightIndex]
        index += 1
        rightIndex += 1

    for i in range(left, right):
        arr[i] = temp[i]
