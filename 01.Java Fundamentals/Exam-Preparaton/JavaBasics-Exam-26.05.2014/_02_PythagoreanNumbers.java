import java.util.Scanner;

public class _02_PythagoreanNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int count = Integer.parseInt(sc.nextLine());
        int[] numbers = new int[count];
        for (int i = 0; i < count; i++) {
            numbers[i] = Integer.parseInt(sc.nextLine());
        }
        boolean isFound = false;

        for (int i = 0; i < numbers.length; i++) {
            for (int j = 0; j < numbers.length; j++) {
                for (int k = 0; k < numbers.length; k++) {
                    int a = numbers[i];
                    int b = numbers[j];
                    int c = numbers[k];
                    if(a < b || a == b){
                        if(((a * a) + (b * b)) == (c * c)){
                            isFound = true;
                            System.out.printf("%d*%d + %d*%d = %d*%d",
                                    a, a, b, b, c, c);
                            System.out.println();
                        }
                    }
                }
            }
        }
        if(!isFound){
            System.out.println("No");
        }
    }
}
