//Write a program that enters an array of strings and finds in it the
// largest sequence of equal elements. If several sequences have the same
// longest length, print the leftmost of them. The input strings are given
// as a single line, separated by a space

import java.util.Scanner;

public class _03_LargestSequenceOfEqualStrings {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");

        int longest = 1;
        int startIndex = 0;

        for (int i = 0; i < input.length; i++) {
            String currStr = input[i];
            int currSequence = 1;
            int currIndex = i;

            for (int j = i + 1; j < input.length; j++) {
                String compareStr = input[j];
                if (compareStr.equals(currStr)) {
                    currSequence++;
                    i++;
                }
            }
            if (currSequence > longest){
                longest = currSequence;
                startIndex = currIndex;

            }
        }
        for (int i = startIndex; i < startIndex + longest; i++) {
            System.out.print(input[i] + " ");
        }
    }
}