//Write a program that takes as input two integers
// N and M, and randomizes the numbers between them.
// Note that M may be smaller than or equal to N.

import java.util.Random;
import java.util.Scanner;

public class _07_RandomizeNumbersFromNtoM {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        int a = scan.nextInt();
        int b = scan.nextInt();

        int startNumber = Math.min(a, b);
        int endNumber = Math.max(a,b);

        Random random = new Random();

        for (int i = startNumber; i <= endNumber; i++) {

            int randomNumber = random.nextInt((endNumber - startNumber)+ 1) + startNumber;
            System.out.print(randomNumber + " ");

        }

    }
}