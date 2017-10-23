//Use the .sorted() method to sort an array of integers. The first line
// of input is the array. The second is the sorting order.

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class _14_SortArrayWithStreamAPI {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        List<String> numbers = new ArrayList<>(Arrays.asList(scanner.nextLine().split(" ")));
        String order = scanner.nextLine();

        if (order.equals("Ascending")){
           numbers.stream().
                   sorted().
                   forEach(x -> System.out.print(x + " "));
        } else {
            numbers.stream().
                    sorted((num1, num2)-> num2.compareTo(num1)).
                    forEach(num -> System.out.print(num + " "));
        }
    }
}