//Write a program to find how many times given string appears in given text as substring.
// The text is given at the first input line. The search string is given at the second input line.
// The output is an integer number. Please ignore the character casing.

import java.util.Scanner;

public class _07_CountSubstringOccurrences {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        String searchString = scanner.nextLine().toLowerCase();

        int counter = 0;
        for (int i = 0; i < input.length() - searchString.length() + 1; i++) {

            String substring = input.substring(i, i + searchString.length());
            if (substring.toLowerCase().equals(searchString)){
                counter++;
            }
        }
        System.out.println(counter);
    }
}