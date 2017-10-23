import java.util.Scanner;

public class _03_LongestOddEvenSequence {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("[ ()]+");
        int[] numbers = new int[input.length - 1];
        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.parseInt(input[i + 1]);
        }
        int bestLen = 0;
        int len = 0;
        boolean shouldBeOdd = numbers[0] % 2 != 0;
        for (int number : numbers){
            boolean isOdd = number % 2 != 0;
            if(isOdd == shouldBeOdd || number == 0){
                len++;
            } else {
                shouldBeOdd = isOdd;
                len = 1;
            }
            shouldBeOdd = !shouldBeOdd;
            if(len > bestLen){
                bestLen = len;
            }
        }
        System.out.println(bestLen);
    }
}