package searchers;

import searchers.base.Searcher;

import java.util.List;

public class InterpolationSearcher implements Searcher<Integer> {
    @Override
    public int search(List<Integer> values, Integer value) {
        int l = 0;
        int r = values.size() - 1;

        while (
            !values.get(l).equals(values.get(r)) &&
                values.get(l) <= value &&
                value <= values.get(r)) {

            int mid = l + ((value - values.get(l)) * (r - l) / (values.get(r) - values.get(l)));
            if (values.get(mid).equals(value)) {
                return mid;
            } else if (values.get(mid) < value) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }

        if (values.get(l).equals(value)) {
            return l;
        }
        return -1;
    }
}
