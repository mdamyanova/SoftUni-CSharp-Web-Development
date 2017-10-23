import java.util.Scanner;

public class _01_StuckNumbers {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String n = scanner.nextLine();
        String[] numbers = scanner.nextLine().split(" ");
        boolean isFound = false;


        for (String a : numbers) {
            for (String b : numbers) {
                for (String c : numbers) {
                    for (String d : numbers) {
                        if (!a.equals(b) &&
                                !a.equals(c) &&
                                !a.equals(d) &&
                                !b.equals(c) &&
                                !b.equals(d) &&
                                !c.equals(d)) {
                            if ((a + b).equals((c + d))) {
                                System.out.printf("%s|%s==%s|%s\n",
                                        a, b, c, d);

                                isFound = true;
                            }
                        }
                    }
                }
            }
        }
        if (isFound == false) {
            System.out.println("No");
        }
    }
}