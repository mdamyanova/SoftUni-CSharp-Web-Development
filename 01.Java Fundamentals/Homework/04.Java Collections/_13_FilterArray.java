//Write a program that filters an array of strings, leaving only the
// strings with length greater than 3 characters. Use .filter()

import java.util.Arrays;
import java.util.Scanner;

public class _13_FilterArray {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split("\\s");
        Arrays.stream(input).filter(x -> x.length() > 3).forEach(result -> System.out.print(result + " "));

    }
}