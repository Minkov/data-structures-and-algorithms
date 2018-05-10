package sorters;

import sorters.base.Sorter;

import java.util.ArrayList;
import java.util.List;

public class BubbleSorter<T extends Comparable<T>> implements Sorter<T> {
    private final Comparer<T> comparer;

    public BubbleSorter() {
        this(Comparer.DefaultComparerer());
    }

    public BubbleSorter(Comparer<T> comparer) {
        this.comparer = comparer;
    }

    @Override
    public List<T> sort(List<T> values) {
        boolean isSwapMade = true;
        List<T> valuesToSort = new ArrayList<>(values);

        while (isSwapMade) {
            isSwapMade = false;
            for (int i = 0; i < valuesToSort.size() - 1; i++) {
                if (this.comparer.compare(valuesToSort.get(i), valuesToSort.get(i + 1)) < 0) {
                    T temp = valuesToSort.get(i);
                    valuesToSort.set(i, valuesToSort.get(i + 1));
                    valuesToSort.set(i + 1, temp);
                    isSwapMade = true;
                }
            }
        }

        return valuesToSort;
    }
}
