//Write a program that reads three floating point numbers
// from the console and calculates their result with given formulae.
//Then calculate the difference between the average of the three
// numbers and the average of the two formulae.

import java.util.Scanner;

public class _04_CalculateExpression {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        Double a = Double.parseDouble(scan.next());
        Double b = Double.parseDouble(scan.next());
        Double c = Double.parseDouble(scan.next());

        double operationsForF1 = ((Math.pow(a, 2) + Math.pow(b, 2))
                / (Math.pow(a,2) - Math.pow(b,2)));
        double f1 = Math.pow(operationsForF1, (a + b + c) / Math.sqrt(c));

        double operationsForF2 = Math.pow(a,2)+Math.pow(b,2)- Math.pow(c,3);
        double f2 = Math.pow(operationsForF2, a - b);

        double diff = Math.abs(((a + b + c) / 3) - ((f1 + f2 ) /2));

        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f", f1, f2, diff);

    }
}