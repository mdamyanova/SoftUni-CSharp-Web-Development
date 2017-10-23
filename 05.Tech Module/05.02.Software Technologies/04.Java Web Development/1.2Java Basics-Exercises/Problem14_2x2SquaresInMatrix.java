import java.util.Scanner;

public class Problem14_2x2SquaresInMatrix {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String[] tokens = scan.nextLine().split(" ");
		int rows = Integer.parseInt(tokens[0]);
		int cols = Integer.parseInt(tokens[1]);

		String[][] matrix = new String[rows][cols];
		for(int row = 0; row < rows; row++){
			String[] line = scan.nextLine().split(" ");
			for(int col = 0; col < cols; col++){
				matrix[row][col] = line[col];
			}
		}
		
		int count = 0;
		for(int row = 0; row < rows - 1; row++){
			for(int col = 0; col < cols - 1; col++){
				String upleft = matrix[row][col];
				String upright = matrix[row][col+1];
				String downleft = matrix[row+1][col];
				String downright = matrix[row+1][col+1];
				
				if(upleft.equals(upright) && downleft.equals(downright) && upleft.equals(downleft)){
					count++;
				}
			}
		}
		
		System.out.println(count);
	}
}