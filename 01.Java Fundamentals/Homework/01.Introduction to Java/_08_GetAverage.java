//Create a method that finds the average of three numbers.
// Read in internet about java methods.
// Check the naming conventions.
// Invoke your method and test it.
// Format the output to two digits after
// the decimal separator. The placeholder is %.2f

import java.util.Scanner;

public class _08_GetAverage {
    public static void main(String[] args){

        Scanner input = new Scanner(System.in);

        double a = Double.parseDouble(input.nextLine());
        double b = Double.parseDouble(input.nextLine());
        double c = Double.parseDouble(input.nextLine());

        System.out.printf("%.2f ", getAverageValue(a, b, c));
    }

    private static double getAverageValue(double a, double b, double c) {
        double average = (a + b + c) / 3;

        return average;
    }
}