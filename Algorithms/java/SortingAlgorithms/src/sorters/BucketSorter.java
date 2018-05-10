package sorters;

import sorters.base.Sorter;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Supplier;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class BucketSorter implements Sorter<Integer> {
    private static final int DEFAULT_BUCKET_COUNT = 1 << 10;
    private final Comparer<Integer> comparer;

    public BucketSorter() {
        this(Sorter.Comparer.DefaultComparerer());
    }

    public BucketSorter(Comparer<Integer> comparer) {
        this.comparer = comparer;
    }

    @Override
    public List<Integer> sort(List<Integer> values) {
        throw new NotImplementedException();
    }
}
