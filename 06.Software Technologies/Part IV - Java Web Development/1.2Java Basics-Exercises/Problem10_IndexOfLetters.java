import java.util.Scanner;

public class Problem10_IndexOfLetters {

	public static void main(String[] args){
		Scanner scan = new Scanner(System.in);
		String word = scan.nextLine();
		for(char letter : word.toCharArray()){
			System.out.println(letter + " -> " + (letter - 'a'));
		}
	}
}