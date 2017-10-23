//Create a method that takes two strings as arguments and
// returns the sum of their character codes multiplied.
//If one of the strings is longer than the other, add
// the remaining character codes to the total sum without
// multiplication.

import java.util.Scanner;

public class _12_CharacterMultiplier {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        String[] input = scan.nextLine().split(" ");
        System.out.println(calculateSum(input[0], input[1]));

    }

    private static int calculateSum(String firstStr, String secondStr){

        int length = firstStr.length();
        if (secondStr.length() < firstStr.length()){
            length = secondStr.length();
        }

        int sum = 0;
        int countIndexes = 0;

        for (int i = 0; i < length; i++) {

            sum += firstStr.charAt(i) * secondStr.charAt(i);
            countIndexes++;
        }

        if (firstStr.length() > secondStr.length()){
            for (int i = countIndexes; i < firstStr.length(); i++) {
                sum += firstStr.charAt(i);
            }
        }else if(secondStr.length() > firstStr.length()){
            for (int i = countIndexes; i < secondStr.length(); i++) {
                sum += secondStr.charAt(i);
            }
        }

        return sum;
    }
}