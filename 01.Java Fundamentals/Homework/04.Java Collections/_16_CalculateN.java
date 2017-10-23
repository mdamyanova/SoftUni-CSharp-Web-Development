//Write a program that recursively calculates factorial.

import java.util.Scanner;

public class _16_CalculateN {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        int number = scanner.nextInt();
        long factorial = calculateFactorial(number);

        System.out.println(factorial);
    }

    private static long calculateFactorial(int number) {
        if (number == 1 || number == 0){
            return  1;
        }
        return number * calculateFactorial(number - 1);
    }
}