import java.util.Arrays;
import java.util.Scanner;

public class Problem19_CensorEmailAddress {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String email = scan.nextLine();
		String input = scan.nextLine();
		String username = email.substring(0, email.indexOf('@'));
		String domain = email.substring(email.indexOf('@'));
		
		char[] chars = new char[username.length()];
		Arrays.fill(chars, '*');
		
		String replacement = new String(chars);
		input = input.replace(email, replacement + domain);
		
		System.out.print(input);
	}
}