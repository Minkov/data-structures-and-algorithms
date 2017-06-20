from .heapsort import sort

tests = [
    [1, 2, 3, 4],
    [4, 3, 2, 1],
    [],
    [1],
    [2, 2, 2, 2],
    [2, 2, 2],
    [3, 8, 9, 3],
    [1, 2, 1, 3, 4, 5, 6, 1],
]


for test in tests:
    initial = test.__str__()
    result = sort(test).__str__()
    print('%s -> %s' % (initial, result))
