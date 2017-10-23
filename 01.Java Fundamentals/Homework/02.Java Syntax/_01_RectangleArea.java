//Write a program that enters the sides of a rectangle
// (two integers a and b) and calculates and prints
// the rectangle's area.

import java.util.Scanner;

public class _01_RectangleArea {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        int a = scan.nextInt();
        int b = scan.nextInt();

        int area = a * b;
        System.out.println(area);
    }
}