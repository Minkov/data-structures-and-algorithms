package sorters;

import sorters.base.Sorter;

import java.util.ArrayList;
import java.util.List;

public class QuickSorter<T extends Comparable<T>> implements Sorter<T> {

    private final Comparer<T> comparer;

    public QuickSorter() {
        this(Comparer.DefaultComparerer());
    }

    public QuickSorter(Comparer<T> comparer) {
        this.comparer = comparer;
    }


    @Override
    public List<T> sort(List<T> values) {
        List<T> valuesToSort = new ArrayList<>(values);
        sort(valuesToSort, 0, valuesToSort.size() - 1);

        return valuesToSort;
    }

    private void sort(List<T> values, int left, int right) {
        int index = partition(values, left, right);

        if (left < index - 1) {
            sort(values, left, index - 1);
        }
        if (index < right) {
            sort(values, index, right);
        }
    }

    private int partition(List<T> values, int left, int right) {
        int i = left;
        int j = right;

        T pivot = values.get((left + right) / 2);

        while (i <= j) {
            while (this.comparer.compare(values.get(i), pivot) < 0) {
                ++i;
            }

            while (this.comparer.compare(pivot, values.get(j)) < 0) {
                --j;
            }

            if (i <= j) {
                swap(values, i, j);
                ++i;
                --j;
            }
        }

        return i;
    }

    private <T extends Comparable<T>> void swap(List<T> values, int i, int j) {
        T temp = values.get(i);
        values.set(i, values.get(j));
        values.set(j, temp);
    }
}
