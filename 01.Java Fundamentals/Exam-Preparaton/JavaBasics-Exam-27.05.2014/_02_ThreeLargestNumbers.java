import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Scanner;

public class _02_ThreeLargestNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        BigDecimal[] numbers = new BigDecimal[n];
        for (int i = 0; i < n; i++) {
            String number = sc.nextLine();
            numbers[i] = new BigDecimal(number);
        }
        Arrays.sort(numbers);
        int count = 3;
        for (int i = numbers.length - 1; i >= 0 && count > 0; i--, count--) {
            System.out.println(numbers[i].toPlainString());
        }
    }
}