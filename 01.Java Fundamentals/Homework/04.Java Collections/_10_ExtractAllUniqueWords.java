//At the first line at the console you are given a piece of text.
// Extract all words from it and print them in alphabetical order.
// Consider each non-letter character as word separator.
// Take the repeating words only once. Ignore the character casing.
// Print the result words in a single line, separated by spaces.

import java.util.*;

public class _10_ExtractAllUniqueWords {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine().toLowerCase();
        String[] words = input.split("[^a-zA-Z]+");

        HashSet<String> uniqueWords = new HashSet<>();
        for (int i = 0; i < words.length; i++) {
            uniqueWords.add(words[i]);
        }

        ArrayList<String> ordered = new ArrayList(uniqueWords);
        Collections.sort(ordered);
        for (int i = 0; i < ordered.size(); i++) {
            System.out.print(ordered.get(i) + " ");
        }
    }
}