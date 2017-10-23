//. The game uses a standard deck of 52 cards. The card faces are: 2, 3, 4, 5, 6, 7, 8, 9, 
//10, J, Q, K and A. The cards suits are denoted by the letters S (spades), H (hearts),
//D (diamonds) and C (clubs). The player is given a hand of cards, a string (“odd” or “even”),
//and a magic card. You need to count the sum of all cards at odd or even positions (positions
//start from 0). Card values are the following: 2 -> 20, 3 -> 30, 4 -> 40, 5 -> 50, 6 -> 60, 
//7 -> 70, 8 -> 80, 9 -> 90, 10 -> 100, J -> 120, Q -> 130, K -> 140, A -> 150. When a card’s 
//suit is the same as the suit of the magic card its value is doubled. When a card’s face is 
//the same as the face of the magic card its value is tripled. The input hand will not contain 
//the magic card.

using System;
using System.Collections.Generic;

class MagicCard
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] cards = input.Split();
        string oddOrEven = Console.ReadLine();
        string magicCard = Console.ReadLine();

        List<string> cardsForCount = new List<string>();
        
        FillTheList(cards, cardsForCount, oddOrEven);
        int result = CountTheSum(cardsForCount, magicCard);
        Console.WriteLine(result);

    }

    private static void FillTheList(string[] cards, List<string> cardsForCount, string oddOrEven)
    {
        if (oddOrEven == "even")
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (i % 2 == 0)
                {
                    cardsForCount.Add(cards[i]);
                }
            } 
        }
        else if (oddOrEven == "odd")
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (i % 2 == 1)
                {
                    cardsForCount.Add(cards[i]);
                }
            }
        }
    }

    private static int CountTheSum(List<string> cardsForCount, string magicCard)
    {
        int value = 0;
        int currentSum = 0;
        foreach (string card in cardsForCount)
        {
            switch (card[0])
            {                
                case '2':
                    currentSum += 20;
                    break;
                case '3':
                    currentSum += 30;
                    break;
                case '4':
                    currentSum += 40;
                    break;
                case '5':
                    currentSum += 50;
                    break;
                case '6':
                    currentSum += 60;
                    break;
                case '7':
                    currentSum += 70;
                    break;
                case '8':
                    currentSum += 80;
                    break;
                case '9':
                    currentSum += 90;
                    break;
                case 'J':
                    currentSum += 120;
                    break;
                case 'Q':
                    currentSum += 130;
                    break;
                case 'K':
                    currentSum += 140;
                    break;
                case 'A':
                    currentSum += 150;
                    break;
                default:
                    currentSum += 100;
                    break;
             }

            if (card[0] == magicCard[0])
            {
                currentSum = currentSum*3;
            }

            //Check if card face is 10 and define face and suit
            string cardSuit = card[1].ToString();

            if (card.Contains("10"))
            {
                cardSuit = card.Substring(2);
            }

            string magicCardSuit = magicCard[1].ToString();

            if (magicCard.Contains("10"))
            {
                magicCardSuit = magicCard.Substring(2);
            }

            if (cardSuit == magicCardSuit)
            {
                currentSum = currentSum*2;
            }

            value += currentSum;
            currentSum = 0;
        }

        return value;
    }
}