import java.util.Scanner;

public class Problem18_FitStringIn20Chars {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		
		int compareLength = input.length() + 1;
		
		if(compareLength == 21){
			System.out.println(input);
		} else if (compareLength < 21){
			System.out.print(input);
			for(int i = 0; i < 20 - input.length(); i++){
				System.out.print("*");
			}
		} else {
			System.out.println(input.substring(0,  20));
		}
	}
}