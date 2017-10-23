//You are given an array of integers as a single line, separated by a space.
// Write a program that checks consecutive pairs and prints if both are odd/even or not.
// Note that the array length should also be an even number.

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _08_OddOrEvenPairs {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        String[] line = scan.nextLine().split(" ");


        if (line.length % 2 == 0) {
            List<Integer> numbers = new ArrayList<>();
            fillList(line, numbers);
            checkConsecutivePairs(numbers);
        }else {
            System.out.println("Invalid length");
        }

    }

    private static void checkConsecutivePairs(List<Integer> numbers) {
        for (int i = 0; i < numbers.size() - 1; i+= 2) {
            if (numbers.get(i) % 2 == 0 && numbers.get(i + 1) % 2 == 0) {
                System.out.printf("%d, %d -> both are even", numbers.get(i), numbers.get(i + 1));

            } else if(numbers.get(i) % 2 == 1 && numbers.get(i + 1) % 2 == 1){
                System.out.printf("%d, %d -> both are odd", numbers.get(i), numbers.get(i + 1));
            } else {
                System.out.printf("%d, %d -> different", numbers.get(i), numbers.get(i + 1));
            }

            System.out.println();
        }
    }

    private static void fillList(String[] line, List<Integer> numbers) {

        for (int i = 0; i < line.length; i++) {
            numbers.add(Integer.parseInt(line[i]));
        }
    }
}