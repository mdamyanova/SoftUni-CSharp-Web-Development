import java.util.Scanner;

public class Problem03_ThreeIntegersSum {
	
	public static void main(String[] args){
		Scanner scan = new Scanner(System.in);
		int num1 = scan.nextInt();
		int num2 = scan.nextInt();
		int num3 = scan.nextInt();
		
		if(!checkThreeIntegers(num1, num2, num3) &&
				!checkThreeIntegers(num3, num1, num2) &&
				!checkThreeIntegers(num2, num3, num1)){
			System.out.println("No");
		}
	}
	
	static boolean checkThreeIntegers(int num1, int num2, int sum){
		if(num1 + num2 != sum){
			return false;
		}
		if(num1 <= num2){
			System.out.printf("%d + %d = %d\n", num1, num2, sum);
			return true;
		} else {
			System.out.printf("%d + %d = %d\n", num2, num1, sum);
			return true;
		}
	}
}
