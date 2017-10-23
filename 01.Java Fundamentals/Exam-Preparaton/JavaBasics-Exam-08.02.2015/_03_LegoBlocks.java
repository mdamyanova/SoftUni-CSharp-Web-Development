import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class _03_LegoBlocks {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        ArrayList<ArrayList<Integer>> firstMatrix = new ArrayList<>();
        ArrayList<ArrayList<Integer>> secondMatrix = new ArrayList<>();
        fillMatrix(sc, n, firstMatrix);
        fillMatrix(sc, n, secondMatrix);
        mergeMatrices(firstMatrix, secondMatrix);

        boolean isMatrix = false;
        int size = firstMatrix.get(0).size();
        for (int i = 1; i < firstMatrix.size(); i++) {
            if(size == firstMatrix.get(i).size()){
                isMatrix = true;
            } else {
                isMatrix = false;
                break;
            }
        }

        if(isMatrix){
            for (ArrayList<Integer> integers : firstMatrix){
                System.out.println(integers);
            }
        } else {
            int count = 0;
            for (ArrayList<Integer> integers : firstMatrix) {
                count += integers.size();
            }
            System.out.println("The total number of cells is: " + count);
        }
    }

    private static void mergeMatrices(ArrayList<ArrayList<Integer>> firstMatrix,
                                      ArrayList<ArrayList<Integer>> secondMatrix) {

        for (int i = 0; i < firstMatrix.size(); i++) {
            Collections.reverse(secondMatrix.get(i));
            firstMatrix.get(i).addAll(secondMatrix.get(i));
        }
    }

    private static void fillMatrix(Scanner sc, int n, ArrayList<ArrayList<Integer>> matrix) {
        for (int i = 0; i < n; i++) {
            matrix.add(new ArrayList<>());
            String[] input = sc.nextLine().trim().split("\\s+");
            for(String num : input){
                matrix.get(i).add(Integer.parseInt(num));
            }
        }
    }
}