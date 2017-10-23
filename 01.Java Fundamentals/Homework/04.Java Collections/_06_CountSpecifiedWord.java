//Write a program to find how many times a word appears in given text. The text is
// given at the first input line. The target word is given at the second input line.
// The output is an integer number. Please ignore the character casing. Consider
// that any non-letter character is a word separator.

import java.util.Scanner;

public class _06_CountSpecifiedWord {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split("[^a-zA-Z]+");
        String word = scanner.nextLine().toLowerCase();

        int counter = 0;
        for (int i = 0; i < input.length; i++) {
            String currString = input[i].toLowerCase();
            if (currString.equals(word)){
                counter++;
            }
        }

        System.out.println(counter);
    }
}