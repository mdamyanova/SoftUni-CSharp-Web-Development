//We are given a sequence of N playing cards from a standard deck. The input consists
// of several cards (face + suit), separated by a space. Write a program to calculate
// and print at the console the frequency of each card face
// in format "card_face -> frequency".

import java.util.*;

public class _12_CardsFrequencies {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().split(" ");
        int length = input.length;
        LinkedHashMap<String, Integer> cards = new LinkedHashMap<>();

        for (int i = 0; i < length; i++) {
            String cardFace = input[i].substring(0, input[i].length() - 1);
            if(!cards.containsKey(cardFace)){
                cards.put(cardFace, 1);
            } else {
                cards.put(cardFace, cards.get(cardFace) + 1);
            }
        }

        for(Map.Entry<String, Integer> card:cards.entrySet()){
            double percentage = ((double)card.getValue()/length)*100;
            System.out.printf("%s -> %.2f%%", card.getKey(), percentage);
            System.out.println();
        }

    }
}