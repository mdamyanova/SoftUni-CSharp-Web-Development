import java.util.Scanner;

public class Problem02_SumTwoNumbers {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		double num1 = scan.nextDouble();
		double num2 = scan.nextDouble();
		
		System.out.printf("Sum=%.2f", num1 + num2);
	}
}