import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

class Main {
    class range {
        long start;
        long end;
    }

    List<range> combineOverLapping(List<range> ranges) {
        List<range> totalRanges = new ArrayList<>();
        for (range r : ranges) {

            if (totalRanges.isEmpty()) {
                totalRanges.add(r);
                continue;
            }
            List<range> existingRange = totalRanges.stream()
                    .filter(totalRange -> r.start <= totalRange.end && r.end >= totalRange.start)
                    .collect(Collectors.toList());
            if (existingRange.size() > 0) {
                existingRange.forEach(range -> {
                    range.start = Math.min(range.start, r.start);
                    range.end = Math.max(range.end, r.end);
                });
            } else {
                totalRanges.add(r);
            }
        }
        return totalRanges;
    }

    void main() {
        List<range> ranges = new ArrayList<range>();
        List<Long> ingredients = new ArrayList<>();
        Boolean isRange = true;
        try (BufferedReader br = new BufferedReader(new FileReader("data.txt"))) {
            String line;
            while ((line = br.readLine()) != null) {
                if (line.equals("")) {
                    isRange = false;
                    continue;

                }

                if (isRange) {
                    range r = new range();
                    r.start = Long.parseLong(line.split("-")[0]);
                    r.end = Long.parseLong(line.split("-")[1]);
                    ranges.add(r);
                } else {
                    ingredients.add(Long.parseLong(line));
                }
            }
        } catch (IOException e) {
            System.err.println("Error reading file: " + e.getMessage());
        }

        long total = 0;
        for (long item : ingredients) {
            for (range r : ranges) {
                if (item >= r.start && item <= r.end) {
                    total++;
                    break;
                }
            }
        }
        System.out.println(total);

        List<range> combinedRanges = new ArrayList<>();
        while (true) {
            List<range> newRanges = combineOverLapping(ranges);
            if (newRanges.size() == combinedRanges.size()) {
                break;
            }
            combinedRanges = new ArrayList<>(newRanges);
        }
        System.out.println(combinedRanges.size());
        long total2 = 0;
        for (range r : combinedRanges) {
            total2 += r.end - r.start + 1;
        }
        System.out.println(total2);
    }
}