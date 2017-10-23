//Write a program that reads two lists of letters l1 and l2 and combines them: appends all letters
// c from l2 to the end of l1, but only when c does not appear in l1. Print
// the obtained combined list. All lists are given as sequence of letters
// separated by a single space, each at a separate line. Use ArrayList<Character>
// of chars to keep the input and output lists.

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class _09_CombineListsOfLetters {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        ArrayList<Character> firstList = new ArrayList(Arrays.asList(scanner.nextLine().split(" ")));
        ArrayList<Character> secondList = new ArrayList(Arrays.asList(scanner.nextLine().split(" ")));

        for (int i = 0; i < secondList.size(); i++) {
            if(!firstList.contains(secondList.get(i))){
                firstList.add(secondList.get(i));
            }
        }

        for (int i = 0; i < firstList.size(); i++) {
            System.out.print(firstList.get(i) + " ");
        }


    }
}