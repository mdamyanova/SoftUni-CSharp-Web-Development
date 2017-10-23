//Write a program that reads 3 numbers: an integer a (0 ? a ? 500),
// a floating-point b and a floating-point c and prints them in
// 4 virtual columns on the console. Each column should have a width of 10 characters.
// The number a should be printed in hexadecimal, left aligned; then the number a
// should be printed in binary form, padded with zeroes, then the number b should be
// printed with 2 digits after the decimal point, right aligned; the number c should be
// printed with 3 digits after the decimal point, left aligned.

import java.util.Scanner;

public class _03_FormattingNumbers {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        int a = Integer.parseInt(scan.next());
        double b = Double.parseDouble(scan.next());
        double c = Double.parseDouble(scan.next());


        String hex = Integer.toHexString(a).toUpperCase();
        String bin = Integer.toBinaryString(a);

        System.out.printf("%-10s|%s|%10.2f|%-10.3f|",
                hex,
                String.format("%010d", Integer.parseInt(bin)),
                b,
                c);
    }
}