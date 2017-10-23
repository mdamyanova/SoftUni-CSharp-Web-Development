//Write a program to count the number of words
// in given sentence. Use any non-letter character as word separator.

import java.util.Scanner;

public class _05_CountAllWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split("[^a-zA-z]+");
        System.out.println(input.length);
    }
}