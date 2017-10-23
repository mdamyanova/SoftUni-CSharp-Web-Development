//Write a program that enters an array of strings and finds in it all
// sequences of equal elements. The input strings are given as a single line,
// separated by a space.

import java.util.Scanner;

public class _02_SequencesOfEqualStrings {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");

        for (int i = 0; i < input.length; i++) {
            String currStr = input[i];
            System.out.print(currStr);

            for (int j = i + 1; j < input.length; j++) {
                String compareStr = input[j];
                if (compareStr.equals(currStr)){
                    System.out.print( " " + input[j]);
                    i++;
                }
            }
            System.out.println();

        }
    }
}