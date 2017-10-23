//Binary search is an algorithm that works on already sorted arrays.
// Basically, it goes to the middle element and checks it has to continue
// searching to the left, or to the right.
// Return the index of the element, or -1, if the element is not found.

import java.util.Scanner;

public class _15_ImplementRecursiveBinarySearch {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int numberToFind = Integer.parseInt(scanner.nextLine());
        String[] inputNumbers = scanner.nextLine().split(" ");
        int[] numbers = new int[inputNumbers.length];
        for (int i = 0; i < inputNumbers.length; i++) {
            numbers[i] = Integer.parseInt(inputNumbers[i]);
        }

        int startIndex = 0;
        int endIndex = numbers.length - 1;
        System.out.println(performBinarySearch(numbers, numberToFind, startIndex, endIndex));
    }

    private static int performBinarySearch(int[] numbers, int numberToFind, int startIndex, int endIndex) {
        int middleIndex = (startIndex + endIndex) / 2;
        if (startIndex > endIndex){
            return -1;
        }
        if(numbers[middleIndex] == numberToFind){
            while(middleIndex - 1 >= 0 && numbers[middleIndex - 1] == numberToFind){
                middleIndex--;
            }
            return middleIndex;
        } else if(numberToFind < numbers[middleIndex]){
            return performBinarySearch(numbers, numberToFind, startIndex, middleIndex - 1);
        } else {
            return performBinarySearch(numbers,numberToFind, middleIndex + 1, endIndex);
        }
    }
}