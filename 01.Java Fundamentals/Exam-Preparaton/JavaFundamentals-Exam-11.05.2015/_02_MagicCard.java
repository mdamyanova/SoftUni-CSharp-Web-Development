import java.util.Scanner;

public class _02_MagicCard {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] cards = scanner.nextLine().split(" ");
        String oddOrEven = scanner.nextLine();
        String magicCard = scanner.nextLine();

        int value =  calculateValueOfTheHand(cards, oddOrEven, magicCard);
        System.out.println(value);
    }

    private static int calculateValueOfTheHand(String[] cards, String oddOrEven, String magicCard) {
        int currValue = 0;
        int sum = 0;
        String cardFace;
        String cardSuit;
        String magicCardFace;
        String magicCardSuit;

        int remainder = oddOrEven.equals("odd") ? 1:0;
        for (int i = 0; i < cards.length; i++) {
            String card = cards[i];
            if(i % 2 == remainder) {
                if (card.length() == 2) {
                    cardFace = card.substring(0, 1);
                    cardSuit = card.substring(1);
                } else {
                    cardFace = card.substring(0, 2);
                    cardSuit = card.substring(2);
                }

                if (magicCard.length() == 2) {
                    magicCardFace = magicCard.substring(0, 1);
                    magicCardSuit = magicCard.substring(1);
                } else {
                    magicCardFace = magicCard.substring(0, 2);
                    magicCardSuit = magicCard.substring(2);
                }

                switch (cardFace) {
                    case "2":
                        currValue += 20;
                        break;
                    case "3":
                        currValue += 30;
                        break;
                    case "4":
                        currValue += 40;
                        break;
                    case "5":
                        currValue += 50;
                        break;
                    case "6":
                        currValue += 60;
                        break;
                    case "7":
                        currValue += 70;
                        break;
                    case "8":
                        currValue += 80;
                        break;
                    case "9":
                        currValue += 90;
                        break;
                    case "10":
                        currValue += 100;
                        break;
                    case "J":
                        currValue += 120;
                        break;
                    case "Q":
                        currValue += 130;
                        break;
                    case "K":
                        currValue += 140;
                        break;
                    case "A":
                        currValue += 150;
                        break;
                }

                if (cardFace.equals(magicCardFace)) {
                    currValue = currValue * 3;
                }
                if (cardSuit.equals(magicCardSuit)) {
                    currValue = currValue * 2;
                }
                sum += currValue;
                currValue = 0;
            }
        }
        return sum;
    }
}