package sorters;

import sorters.base.Sorter;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class MergeSorter<T extends Comparable<T>> implements Sorter<T> {

    private final Comparer<T> comparer;

    public MergeSorter() {
        this(Comparer.DefaultComparerer());
    }

    public MergeSorter(Comparer<T> comparer) {
        this.comparer = comparer;
    }

    @Override
    public List<T> sort(List<T> values) {
        List<T> valuesToSort = new ArrayList<>(values);
        List<T> temp = Stream.generate(() -> null)
            .map(x -> (T) null)
            .limit(values.size())
            .collect(Collectors.toList());

        sort(valuesToSort, 0, valuesToSort.size(), temp);

        return valuesToSort;
    }

    private void sort(List<T> values, int left, int right, List<T> temp) {
        if (right - left == 1) {
            return;
        }

        int mid = (left + right) / 2;
        sort(values, left, mid, temp);
        sort(values, mid, right, temp);
        merge(values, left, mid, right, temp);
    }

    private void merge(List<T> values, int left, int mid, int right, List<T> temp) {
        int index = left;

        int i = left;
        int j = mid;

        while (i < mid && j < right) {
            if (this.comparer.compare(values.get(i), values.get(j)) < 0) {
                temp.set(index, values.get(i));
                ++index;
                ++i;
            } else {
                temp.set(index, values.get(j));
                ++index;
                ++j;
            }
        }

        while (i < mid) {
            temp.set(index, values.get(i));
            ++i;
            ++index;
        }

        while (j < right) {
            temp.set(index, values.get(j));
            ++j;
            ++index;
        }

        for (int k = left; k < right; k++) {
            values.set(k, temp.get(k));
        }
    }
}
