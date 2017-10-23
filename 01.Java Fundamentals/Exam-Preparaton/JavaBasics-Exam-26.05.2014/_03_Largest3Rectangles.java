import java.util.Scanner;

public class _03_Largest3Rectangles {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        input = input.replace("[", "");
        input = input.replace(" ", "");
        String[] numbers = input.split("]");

        int[] areas = new int[numbers.length];
        for (int i = 0; i < numbers.length; i++) {
            String currRect = numbers[i];
            currRect = currRect.replace("[", "");
            String[] sizes = currRect.split("x");
            int a = Integer.parseInt(sizes[0]);
            int b = Integer.parseInt(sizes[1]);
            areas[i] = a * b;
        }

        int max = Integer.MIN_VALUE;
        for (int i = 2; i < areas.length; i++) {
            int sum = areas[i - 2] + areas[i - 1] + areas[i];
            if(sum > max){
                max = sum;
            }
        }
        System.out.println(max);
    }
}