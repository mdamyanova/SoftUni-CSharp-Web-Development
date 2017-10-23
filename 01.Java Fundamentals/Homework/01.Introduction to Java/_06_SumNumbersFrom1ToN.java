//Create a Java program that reads a number N from the
// console and calculates the sum of all numbers from 1 to N (inclusive).

import java.util.Scanner;

public class _06_SumNumbersFrom1ToN {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        int n = Integer.parseInt(input.nextLine());

        int sum = 0;
        for (int i = 1; i <= n; i++) {

            sum += i;

        }
        System.out.println(sum);
    }
}