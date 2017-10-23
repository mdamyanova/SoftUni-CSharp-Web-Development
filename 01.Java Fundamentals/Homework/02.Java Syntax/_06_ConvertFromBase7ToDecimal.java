//Write a program that converts from
// a base-7 number to its decimal representation.

import java.util.Scanner;

public class _06_ConvertFromBase7ToDecimal {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        String number = scan.next();

        System.out.println(Integer.parseInt(number, 7));
    }
}