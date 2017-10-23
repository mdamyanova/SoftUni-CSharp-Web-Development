import java.util.Scanner;

public class Problem05_SymmetricNumbers {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		int n = scan.nextInt();
		
		for(int i = 1; i <= n; i++){
			if(isSymmetric("" + i)){
				System.out.print(i + " ");
			}
		}
	}
	
	static boolean isSymmetric(String str){
		for(int i = 0; i < str.length() / 2; i++){
			if(str.charAt(i) != str.charAt(str.length() - 1 - i)){
				return false;
			}
		}
		return true;
	}
}