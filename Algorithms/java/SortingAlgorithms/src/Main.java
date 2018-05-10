import sorters.CountingSorter;
import sorters.base.Sorter;

import java.util.*;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        Queue<Integer> queue = new LinkedList<>();

        Sorter<Integer> sorter = new CountingSorter();

        List<Integer> list = Arrays.asList(5, 1, 2, 3, 1, 2, 3);

        System.out.println(
            sorter.sort(list)
                .stream()
                .map(Object::toString)
                .collect(Collectors.joining(", "))
        );
    }
}
