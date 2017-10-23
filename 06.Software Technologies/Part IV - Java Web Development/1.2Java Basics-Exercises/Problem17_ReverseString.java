import java.util.Scanner;

public class Problem17_ReverseString {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String word = scan.nextLine();
		for(int i = word.length() - 1; i >= 0; i--){
			System.out.print(word.charAt(i));
		}
	}
}