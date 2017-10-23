import java.util.Scanner;

public class Problem04_VowelOrDigit {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		char ch  = scan.next().charAt(0);
	
		if(Character.isDigit(ch)){
			System.out.println("digit");
		} else if(ch == 'a' || ch == 'o' || ch == 'e' || ch == 'u' || ch == 'i'){
			System.out.println("vowel");
		} else {
			System.out.println("other");
		}
	}
}