//Write a program that extracts words from a string.
// Words are sequences of characters that are at least
// two symbols long and consist only of English alphabet
// letters. Use regex.

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _10_ExtractWords {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();

        Pattern pattern = Pattern.compile("[A-Za-z]+");
        Matcher match = pattern.matcher(input);

        while(match.find()){
            System.out.print(match.group() + " ");
        }
    }
}