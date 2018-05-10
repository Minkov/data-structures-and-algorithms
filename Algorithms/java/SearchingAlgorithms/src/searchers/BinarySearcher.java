package searchers;

import searchers.base.Searcher;

import java.util.List;

public class BinarySearcher<T extends Comparable<T>> implements Searcher<T> {
    @Override
    public int search(List<T> values, T value) {
        int l = 0;
        int r = values.size();

        while (l < r) {
            int mid = (l + r) / 2;

            if (value.compareTo(values.get(mid)) == 0) {
                return mid;
            } else if (value.compareTo(values.get(mid)) < 0) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }

        return -1;
    }
}
