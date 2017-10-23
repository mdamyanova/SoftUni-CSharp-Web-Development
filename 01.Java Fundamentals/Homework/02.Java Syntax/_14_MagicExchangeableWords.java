//Write a method that takes as input two strings of equal length,
//and returns Boolean if they are exchangeable or not. Exchangeable
// are words where the characters in the first string can be replaced
// to get the second string.

import java.util.HashMap;
import java.util.Scanner;

public class _14_MagicExchangeableWords {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        String[] input = scan.nextLine().split(" ");

        System.out.println(exchangeableWords(input));
    }

    private static boolean exchangeableWords(String[] input) {

        HashMap<Character, Character> charSaver = new HashMap<>();
        String firstStr = input[0];
        String secondStr = input[1];

        for (int i = 0; i < firstStr.length(); i++) {

           char currCharOfFirst = firstStr.charAt(i);
           char currCharOfSecond = secondStr.charAt(i);

            if (charSaver.containsKey(currCharOfFirst)){
                if (charSaver.get(currCharOfFirst) != currCharOfSecond){

                    return false;
                }
            } else {
                if (charSaver.containsValue(currCharOfSecond)){
                    return false;
                }

                charSaver.put(currCharOfFirst, currCharOfSecond);
            }
        }
        return true;
    }
}