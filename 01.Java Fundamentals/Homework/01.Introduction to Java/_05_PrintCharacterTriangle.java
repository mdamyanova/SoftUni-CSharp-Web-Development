//Create a triangle of characters, based on input.
// Learn about java.util.Scanner and Integer.parseInt ().
// Test your program with integers up to 26. Think why.

import java.util.Scanner;

public class _05_PrintCharacterTriangle {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        int inputNumber = Integer.parseInt(input.nextLine());

        for (int i = 0; i <= inputNumber; i++) {
            for (int j = 0; j < i; j++) {
                System.out.print((char)('a' + j) + " ");
            }
            System.out.println();
        }

        for (int i = inputNumber - 1; i >= 0; i--) {
            for (int j = 0; j < i; j++) {
                System.out.print((char)('a' + j) + " ");
            }
            System.out.println();
        }


    }
}