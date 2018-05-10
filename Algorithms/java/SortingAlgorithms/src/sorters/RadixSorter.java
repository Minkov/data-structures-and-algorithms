package sorters;

import sorters.base.Sorter;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Supplier;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class RadixSorter implements Sorter<Integer> {

    @Override
    public List<Integer> sort(List<Integer> values) {
        int base = 2;
        int iteration = 0;
        int max = values.stream()
            .max(Integer::compareTo)
            .get();

        List<Integer> valuesToSort = new ArrayList<>(values);

        while (Math.pow(base, iteration) < max) {
            valuesToSort = bucketsToList(listToBuckets(valuesToSort, base, iteration));
            ++iteration;
        }

        return valuesToSort;
    }

    private List<Integer> bucketsToList(List<List<Integer>> buckets) {
        List<Integer> list = new ArrayList<>();
        for (List<Integer> bucket : buckets) {
            list.addAll(bucket);
        }

        return list;
    }

    List<List<Integer>> listToBuckets(List<Integer> list, int base, int iteration) {
        List<List<Integer>> buckets = Stream.generate((Supplier<ArrayList<Integer>>) ArrayList::new)
            .limit(base)
            .collect(Collectors.toList());

        for (int value : list) {
            int digit = (int) ((value / Math.pow(base, iteration)) % base);
            buckets.get(digit)
                .add(value);
        }

        return buckets;
    }
}
