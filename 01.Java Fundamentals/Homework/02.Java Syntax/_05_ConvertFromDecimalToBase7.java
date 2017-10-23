//Write a program that takes an
//integer number and converts it to base-7

import java.util.Scanner;

public class _05_ConvertFromDecimalToBase7 {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        int number = scan.nextInt();

        System.out.println(Integer.toString(number, 7));
    }
}