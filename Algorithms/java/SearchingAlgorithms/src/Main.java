import searchers.InterpolationSearcher;
import searchers.base.Searcher;

import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {

        Arrays.sort();
        Searcher<Integer> searcher = new InterpolationSearcher();

        List<Integer> values = Arrays.asList(1, 2, 3, 4, 5, 6, 7, 8, 9);

        for (int val : values) {
            System.out.println(searcher.search(values, val));
        }
    }
}
