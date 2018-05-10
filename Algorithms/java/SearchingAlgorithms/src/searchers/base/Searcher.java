package searchers.base;

import java.util.List;

public interface Searcher<T> {
    int search(List<T> values, T value);
}
