import java.util.Scanner;

public class Problem13_DiagonalDifference {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int input = Integer.parseInt(scan.nextLine());
        int[][] matrix = new int[input][input];

        for(int row = 0; row < input; row++){
            String[] line = scan.nextLine().split(" ");
            for(int col = 0; col < input; col++){
                matrix[row][col] = Integer.parseInt(line[col]);
            }
        }

        int primarySum = 0;

        //primary diagonal
        for(int i = 0; i < input; i++){
            primarySum += matrix[i][i];
        }

        int secondarySum = 0;

        //secondary diagonal
        for(int i = 0; i < input; i++){
            for(int col = input - 1 - i; col >= 0; col--){
                secondarySum += matrix[i][col];
                i++;
            }
        }

        System.out.println(Math.abs(primarySum - secondarySum));
    }
}