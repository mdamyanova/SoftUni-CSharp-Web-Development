import java.util.Scanner;

public class Problem12_MatrixOfPalindromes {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		int rows = scan.nextInt();
		int cols = scan.nextInt();
		char firstAndLast = 'a';
		char middle = 'a';
		String[][] matrix = new String[rows][cols];
		for(int row = 0; row < rows; row++){
			for(int col = 0; col < cols; col++){
				matrix[row][col] = "" + firstAndLast + middle + firstAndLast;
				middle++;
			}
			
			middle = (char)('b' + row);
			firstAndLast++;
		}
		
		for(int row = 0; row < rows; row++){
			for(int col = 0; col < cols; col++){
				System.out.print(matrix[row][col] + " ");
			}
			
			System.out.println();
		}
	}
}