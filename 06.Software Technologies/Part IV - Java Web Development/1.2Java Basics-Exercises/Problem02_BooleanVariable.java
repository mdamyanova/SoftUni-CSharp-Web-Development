import java.util.Scanner;

public class Problem02_BooleanVariable {
	
	public static void main(String[] args){
		Scanner scan = new Scanner(System.in);
		String word = scan.nextLine();
		
		if(word.equals("True")){
			System.out.println("Yes");
		} else if(word.equals("False")){
			System.out.println("No");
		}
	}
}