package sorters.base;

import java.util.List;

public interface Sorter<T extends Comparable<T>> {
    List<T> sort(List<T> values);

    public interface Comparer<T extends Comparable> {
        public static <V extends Comparable<V>> Comparer<V> DefaultComparerer() {
            return Comparable::compareTo;
        }

        int compare(T x, T y);
    }
}
