//Write a program to find the most frequent word in a text and print it,
// as well as how many times it appears in format "word -> count". Consider
// any non-letter character as a word separator. Ignore the character casing.
// If several words have the same maximal frequency, print all of them in
// alphabetical order.

import java.util.*;

public class _11_MostFrequentWord {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().toLowerCase().split("[^a-zA-Z]+");
        Map<String, Integer> words = new HashMap();

        for (int i = 0; i < input.length; i++) {
            if (!words.containsKey(input[i])){
                words.put(input[i], 1);
            } else{
                words.put(input[i], words.get(input[i]) + 1);
            }
        }

        int maxValue = 0;
        TreeSet<String> mostFrequentWords = new TreeSet<>();
        maxValue = Collections.max(words.values());

        for(String key:words.keySet()){
            if(words.get(key) == maxValue){
                mostFrequentWords.add(key);
            }
        }
        for(String str:mostFrequentWords){
            System.out.println(str+" -> "+ maxValue + " times");
        }
    }
}