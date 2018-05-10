package sorters;

import sorters.base.Sorter;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class CountingSorter implements Sorter<Integer> {
    @Override
    public List<Integer> sort(List<Integer> values) {
        List<Integer> counts = Stream.generate(() -> 0)
            .limit(
                values.stream()
                    .max(Integer::compareTo)
                    .get() + 1)
            .collect(Collectors.toList());

        for (int value : values) {
            counts.set(value, counts.get(value) + 1);
        }

        List<Integer> result = new ArrayList<>();

        for (int i = 0; i < counts.size(); i++) {
            for (int j = 0; j < counts.get(i); j++) {
                result.add(i);
            }
        }

        return result;
    }
}
