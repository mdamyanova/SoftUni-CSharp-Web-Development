//Write a method that returns the first N odd/even elements from
// a collection.Return as many as you can.

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _13_GetFirstOddOrEvenElements {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        String[] inputNumbers = scan.nextLine().split(" ");
        String[] command = scan.nextLine().split(" ");
        List<Integer> numbers = new ArrayList<>();

        for (int i = 0; i < inputNumbers.length; i++) {

            numbers.add(Integer.parseInt(inputNumbers[i]));
        }

        List<Integer> resultNumbers = getFirstOddOrEvenElements(command, numbers);
        for (int i = 0; i < resultNumbers.size(); i++) {

            System.out.print(resultNumbers.get(i) + " ");
        }
    }

    private static List getFirstOddOrEvenElements(String[] command, List<Integer> numbers) {

        List<Integer> resultNumbers = new ArrayList<>();
        int count = Integer.parseInt(command[1]);
        String oddOrEven = command[2];
        int length = count;
        if (count > numbers.size()){
            length = numbers.size() - 1;
        }

        if (oddOrEven.contains("even")) {

            for (int i = 0; i <= length + 1; i++) {

                if (numbers.get(i) % 2 == 0) {
                    resultNumbers.add(numbers.get(i));
                }
            }
        } else if(oddOrEven.contains("odd")){

            for (int i = 0; i <= length + 1; i++) {

                if (numbers.get(i) % 2 == 1) {
                    resultNumbers.add(numbers.get(i));
                }
            }
        }
       return resultNumbers;
    }
}