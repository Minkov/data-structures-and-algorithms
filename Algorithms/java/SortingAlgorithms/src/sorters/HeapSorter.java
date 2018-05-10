package sorters;

import sorters.base.Sorter;

import java.util.ArrayList;
import java.util.List;

public class HeapSorter<T extends Comparable<T>> implements Sorter<T> {

    private final Comparer<T> comparer;

    public HeapSorter() {
        this(Sorter.Comparer.DefaultComparerer());
    }

    public HeapSorter(Comparer<T> comparer) {
        this.comparer = comparer;
    }

    @Override
    public List<T> sort(List<T> values) {
        List<T> valuesToSort = new ArrayList<>(values);
        int n = valuesToSort.size();

        for (int i = n / 2 - 1; i >= 0; i--) {
            heapify(valuesToSort, n, i);
        }

        for (int i = n - 1; i >= 0; i--) {
            swap(valuesToSort, i, 0);
            heapify(valuesToSort, i, 0);
        }

        return valuesToSort;
    }

    private void heapify(List<T> values, int n, int i) {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        if (l < n && this.comparer.compare(values.get(l), values.get(largest)) > 0) {
            largest = l;
        }

        if (r < n && this.comparer.compare(values.get(r), values.get(largest)) > 0) {
            largest = r;
        }

        if (largest != i) {
            swap(values, i, largest);
            heapify(values, n, largest);
        }
    }

    private <T extends Comparable<T>> void swap(List<T> values, int i, int j) {
        T temp = values.get(i);
        values.set(i, values.get(j));
        values.set(j, temp);
    }
}
