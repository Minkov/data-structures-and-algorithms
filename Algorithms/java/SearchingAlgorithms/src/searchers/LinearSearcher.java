package searchers;

import searchers.base.Searcher;

import java.util.List;

public class LinearSearcher<T> implements Searcher<T> {
    @Override
    public int search(List<T> values, T value) {
        for (int i = 0; i < values.size(); i++) {
            if (values.get(i).equals(value)) {
                return i;
            }
        }

        return -1;
    }
}
