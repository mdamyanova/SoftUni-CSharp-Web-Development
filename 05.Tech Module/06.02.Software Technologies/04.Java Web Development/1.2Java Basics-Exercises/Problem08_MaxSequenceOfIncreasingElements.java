import java.util.Scanner;

public class Problem08_MaxSequenceOfIncreasingElements {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int[] numbers = new int[input.length];
        for (int i = 0; i < input.length; i++) {
            numbers[i] = Integer.parseInt(input[i]);
        }

        int index = 0;
        int length = 0;
        for (int i = 0; i < numbers.length; i++) {
            int currNum = numbers[i];
            int currIndex = i;
            int currLength = 1;
         
            for (int j = i + 1; j < numbers.length; j++) {
                int compareNum = numbers[j];
                if (compareNum > currNum){
                   
                    currNum = compareNum;
                    currLength++;
                    i++;
                } else{
                    break;
                }
            }

            if(currLength > length){
                length = currLength;
                index = currIndex;
            }
        }

        for (int i = index; i < index + length; i++) {
            System.out.print(" " + numbers[i]);
        }
	}
}
