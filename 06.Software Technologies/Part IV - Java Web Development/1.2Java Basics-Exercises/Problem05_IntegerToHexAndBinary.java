import java.util.Scanner;

public class Problem05_IntegerToHexAndBinary {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		int num = scan.nextInt();
		
		System.out.println(Integer.toHexString(num).toUpperCase() + "\n" + Integer.toBinaryString(num));
	}
}