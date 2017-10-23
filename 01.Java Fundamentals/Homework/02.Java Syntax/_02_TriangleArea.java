//Write a program that enters 3 points in the plane
// (as integer x and y coordinates), calculates and
// prints the area of the triangle composed by these
// 3 points. Round the result to a whole number.
// In case the three points do not form a triangle,
// print "0" as result.

import java.util.Scanner;

public class _02_TriangleArea {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        int aX = scan.nextInt();
        int aY = scan.nextInt();
        scan.nextLine();

        int bX = scan.nextInt();
        int bY = scan.nextInt();
        scan.nextLine();

        int cX = scan.nextInt();
        int cY = scan.nextInt();

        int area = ((aX * (bY - cY)) + (bX * (cY - aY)) + (cX * (aY - bY))) / 2;

        if (area != 0){
            System.out.println(Math.abs(area));
        } else {
            System.out.println("0");
        }
    }
}