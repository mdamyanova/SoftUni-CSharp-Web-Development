import java.util.Scanner;

public class _02_AddingAngles {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());
        String[] input = sc.nextLine().split(" ");
        int[] numbers = new int[n];
        for (int i = 0; i < input.length; i++) {
            numbers[i] = Integer.parseInt(input[i]);
        }

        boolean isAngle = false;
        for (int a = 0; a < numbers.length; a++) {
            for (int b = a + 1; b < numbers.length; b++) {
                for (int c = b + 1; c < numbers.length; c++) {
                    int currA = numbers[a];
                    int currB = numbers[b];
                    int currC = numbers[c];
                    if((currA + currB +currC) % 360 == 0){
                        System.out.println(currA + " + "
                                + currB + " + "
                                + currC + " = "
                                + (numbers[a] +numbers[b] + numbers[c])
                                + " degrees");
                        isAngle = true;
                    }
                }
            }
        }
        if(!isAngle){
            System.out.println("No");
        }
    }
}
