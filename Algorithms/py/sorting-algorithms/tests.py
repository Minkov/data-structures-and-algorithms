from sorts.mergesort import sort
# from sorts.heapsort import sort
import time

n = 1 << 20 

arr = list(range(n))[::-1]

start = time.time()

sort(arr)

end = time.time()
print(end - start)
