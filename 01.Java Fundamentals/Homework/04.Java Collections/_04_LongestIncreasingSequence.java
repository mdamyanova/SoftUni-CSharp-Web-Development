//Write a program to find all increasing sequences inside an array of
// integers. The integers are given in a single line, separated by a space.
// Print the sequences in the order of their appearance in the input array,
// each at a single line. Separate the sequence elements by a space. Find
// also the longest increasing sequence and print it at the last line. If
// several sequences have the same longest length, print the leftmost of them.

import java.util.Scanner;

public class _04_LongestIncreasingSequence {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int[] numbers = new int[input.length];
        for (int i = 0; i < input.length; i++) {
            numbers[i] = Integer.parseInt(input[i]);
        }

        int index = 0;
        int length = 0;
        for (int i = 0; i < numbers.length; i++) {
            int currNum = numbers[i];
            int currIndex = i;
            int currLength = 1;
            System.out.print(currNum);

            for (int j = i + 1; j < numbers.length; j++) {
                int compareNum = numbers[j];
                if (compareNum > currNum){
                    System.out.print(" " + compareNum);
                    currNum = compareNum;
                    currLength++;
                    i++;
                } else{
                    break;
                }
            }

            if(currLength > length){
                length = currLength;
                index = currIndex;
            }
            System.out.println();
        }

        System.out.print("Longest:");
        for (int i = index; i < index + length; i++) {
            System.out.print(" " + numbers[i]);
        }
    }
}