import java.util.Scanner;

public class Problem15_MaxPlatform3x3 {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String[] tokens = scan.nextLine().split(" ");
		int rows = Integer.parseInt(tokens[0]);
		int cols = Integer.parseInt(tokens[1]);
		long[][] matrix = new long[rows][cols];
		
		fillMatrix(matrix, rows, cols, scan);
		
		long maxSum = Long.MIN_VALUE;
		long[][] result = new long[3][3];
		
		for(int row = 0; row < rows - 2; row++){
			for(int col = 0; col < cols - 2; col++){
				long upleft = matrix[row][col];
                long upmiddle = matrix[row][col + 1];
                long upright = matrix[row][col + 2];
               
                long middleleft = matrix[row + 1][col];
                long middlemiddle = matrix[row + 1][col + 1];
                long middleright = matrix[row + 1][col + 2];
               
                long downleft = matrix[row + 2][col];
                long downmiddle = matrix[row + 2][col + 1];
                long downright = matrix[row + 2][col + 2];
                
                if ((upleft + upmiddle + upright + middleleft + middlemiddle + 
                        middleright + downleft + downmiddle
                         + downright) > maxSum)
                    {
                        maxSum = upleft + upmiddle + upright + middleleft + middlemiddle + middleright + downleft
                                 + downmiddle + downright;

                        result[0][0] = upleft;
                        result[0][1] = upmiddle;
                        result[0][2] = upright;
                        result[1][0] = middleleft;
                        result[1][1] = middlemiddle;
                        result[1][2] = middleright;
                        result[2][0] = downleft;
                        result[2][1] = downmiddle;
                        result[2][2] = downright;
                    }
			}
		}
		
		  System.out.println(maxSum);

          for (int row = 0; row < 3; row++)
          {
              for (int col = 0; col < 3; col++)
              {
                  System.out.print(result[row][col] + " ");
              }

              System.out.println();
          }
      }
	
	private static void fillMatrix(long[][] matrix, int rows, int cols, Scanner scan) {
		for(int row = 0; row < rows; row++){
			String[] line = scan.nextLine().split(" ");
			for(int col = 0; col < cols; col++){
				matrix[row][col] = Integer.parseInt(line[col]);
			}
		}
	}
}